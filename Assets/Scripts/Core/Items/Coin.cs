using Core.Components;
using Core.Player;
using UnityEngine;

namespace Core.Items
{
    public class Coin : MonoBehaviour, IPickUp
    {
        [SerializeField] private int _nominal;

        public void PickUp(PlayerInstance player)
        {
            Destroy(gameObject);
        }
    }
}