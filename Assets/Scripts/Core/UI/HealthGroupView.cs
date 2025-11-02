using System.Collections.Generic;
using Core.Player;
using UnityEngine;

namespace Core.UI
{
    public class HealthGroupView : MonoBehaviour
    {
        [SerializeField] private HealthView _prefab;
        [SerializeField] private PlayerInstance _player;

        private List<HealthView> _views = new();

        public void Start()
        {
            for (var i = 0; i < _player.Health.MaxHealth; i++)
            {
                var heart = Instantiate(_prefab, transform);

                SetVisible(false, heart);

                _views.Add(heart);
            }

            ShowCurrentHealth(_player.Health.CurrentHealth);
        }

        public void ShowCurrentHealth(int currentHealth)
        {
            for (var i = 0; i < _views.Count; i++)
            {
                SetVisible(i < currentHealth, _views[i]);
            }
        }

        private void SetVisible(bool visible, HealthView view)
        {
            view.gameObject.SetActive(visible);
        }
    }
}