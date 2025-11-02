using Core.Components;
using Core.Player;
using UnityEngine;

namespace Core.Items
{
    public class Heal : MonoBehaviour, IPickUp
    {
        [SerializeField] private int _healAmount;
        [SerializeField] private float _amplitude = 0.1f;
        [SerializeField] private float _speed = 1.0f;

        private float _baseScale;

        private void Start()
        {
            _baseScale = transform.localScale.x;
        }

        public void PickUp(PlayerInstance player)
        {
            var health = player.Health;

            if (health.CurrentHealth == health.MaxHealth) return;

            health.Heal(_healAmount);
            Destroy(gameObject);
        }

        private void Update()
        {
            Scaling();
        }

        private void Scaling()
        {
            var scale = 1f + Mathf.Sin(Time.time * _speed) * 0.5f * _amplitude;
            transform.localScale = new Vector3(scale * _baseScale, scale * _baseScale, transform.localScale.z);
        }
    }
}