using Core.Components;
using Core.Player;
using UnityEngine;

namespace Core.Items
{
    public class Coin : MonoBehaviour, IPickUp
    {
        public void PickUp(PlayerInstance player)
        {
            print("coin picked up");
            Destroy(gameObject);
        }
    }
}