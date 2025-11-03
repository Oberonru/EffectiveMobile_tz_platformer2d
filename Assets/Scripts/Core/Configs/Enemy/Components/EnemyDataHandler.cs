using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Core.Configs.Enemy.Components
{
    public class EnemyDataHandler : MonoBehaviour
    {
        [Inject] private StorageService _storage;

        private void Awake()
        {
            var data = _storage.Load();
        }
    }
}