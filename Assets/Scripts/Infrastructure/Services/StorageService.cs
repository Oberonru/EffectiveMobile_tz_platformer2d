using System;
using System.IO;
using Cysharp.Threading.Tasks;
using Storage.Model;
using UniRx;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services
{
    [CreateAssetMenu(menuName = "Infrastructure/Services/StorageService", fileName = "StorageService")]
    public class StorageService : ScriptableService, IInitializable
    {
        public GameData GameData { get; set; }
        public IObservable<Unit> OnLoaded => _onLoaded;
        private Subject<Unit> _onLoaded = new();

        private string _fileName = "game.json";
        private string _folderName = "LocalSave";
        private string _filePath;

        public void Initialize()
        {
            _filePath = Path.Combine(Application.persistentDataPath, _fileName);
            var directory = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public virtual void Save()
        {
            if (!IsReady()) return;


            if (GameData == null)
            {
                Debug.LogWarning("Save called with null GameData.");
                return;
            }

            try
            {
                var json = JsonConvert.SerializeObject(GameData, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save GameData: {e.Message}");
            }
        }

        public async UniTask<GameData> Load()
        {
            if (!IsReady())
            {
                Debug.LogWarning("StorageService not initialized yet. Returning new PlayerData.");
                GameData = new GameData();
                return GameData;
            }

            if (!File.Exists(_filePath))
            {
                GameData = new GameData();
                return GameData;
            }

            try
            {
                var json = await File.ReadAllTextAsync(_filePath);
                GameData = JsonConvert.DeserializeObject<GameData>(json);

                return GameData;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load GameData: {e.Message}");
                GameData = new GameData();
                _onLoaded?.OnNext(Unit.Default);

                return GameData;
            }
        }


        private bool IsReady()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                Debug.LogWarning("SaveLoadService _filePath is not set. Did Initialize run?");
                return false;
            }

            return true;
        }
    }
}