using Core.Player;
using UniRx;
using UnityEngine;

namespace Core.UI
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