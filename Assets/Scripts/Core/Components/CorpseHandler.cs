using UniRx;
using UnityEngine;

namespace Core.Components
{
    public class CorpseHandler : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private float destroyedTime = 1f;

        private void OnEnable()
        {
            _healthComponent.OnDead.DistinctUntilChanged().Subscribe();
        }

        private void HandleDeath()
        {
            
        }
    }
}