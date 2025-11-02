using Core.Components;
using Core.Player;
using UnityEngine;

namespace Core.Items
{
    public class HealComponent : MonoBehaviour, IPickUp
    {
        [SerializeField] private int _healAmount;

        public void PickUp(PlayerInstance player)
        {
            var health = player.Health;

            if (health.CurrentHealth == health.MaxHealth) return;

            health.Heal(_healAmount);
            Destroy(gameObject);
        }
    }
}