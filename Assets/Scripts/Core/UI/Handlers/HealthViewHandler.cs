using Core.Player;
using Core.UI.Views;
using UniRx;
using UnityEngine;

namespace Core.UI.Handlers
{
    public class HealthViewHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInstance _player;
        [SerializeField] private HealthGroupView _healthGroup;

        private void OnValidate()
        {
            if (_player == null) _player = FindObjectOfType<PlayerInstance>();
        }
        
        private void OnEnable()
        {
            _player.Health.OnHealthChanged.Subscribe(health => _healthGroup.
                ShowCurrentHealth(health)).AddTo(this);
        }
    }
}