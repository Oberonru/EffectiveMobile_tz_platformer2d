using Core.BaseComponents;
using Core.Interfaces;
using UnityEngine;

namespace Core.Handlers
{
    [RequireComponent(typeof(HealthComponent))]
    public class StateComponentHandler : MonoBehaviour
    {
        [SerializeField] private HealthComponent _health;
        private IStateComponent[] _stateComponents;

        private void Start()
        {
            _stateComponents = GetComponentsInChildren<IStateComponent>();
        }

        public void DisableAllComponents()
        {
            if (_stateComponents == null) return;
            
            foreach (var component in _stateComponents)
            {
                component?.Disable();
            }
        }

        public void EnableAllComponents()
        {
        }
    }
}