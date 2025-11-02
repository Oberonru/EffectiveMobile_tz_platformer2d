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
        public PlayerData PlayerData { get; set; }
        public IObservable<Unit> OnLoaded => _onLoaded;
        private Subject<Unit> _onLoaded = new();

        private string _fileName = "player.json";
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


            if (PlayerData == null)
            {
                Debug.LogWarning("Save called with null PlayerData.");
                return;
            }

            try
            {
                var json = JsonConvert.SerializeObject(PlayerData, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to save PlayerData: {e.Message}");
            }
        }

        public async UniTask<PlayerData> Load()
        {
            if (!IsReady())
            {
                Debug.LogWarning("StorageService not initialized yet. Returning new PlayerData.");
                PlayerData = new PlayerData();
                return PlayerData;
            }

            if (!File.Exists(_filePath))
            {
                PlayerData = new PlayerData();
                return PlayerData;
            }

            try
            {
                var json = await File.ReadAllTextAsync(_filePath);
                PlayerData = JsonConvert.DeserializeObject<PlayerData>(json);

                return PlayerData;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load PlayerData: {e.Message}");
                PlayerData = new PlayerData();
                _onLoaded?.OnNext(Unit.Default);

                return PlayerData;
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