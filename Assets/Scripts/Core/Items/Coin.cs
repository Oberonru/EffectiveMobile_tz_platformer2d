using Core.Components;
using Core.Player;
using UnityEngine;

namespace Core.Items
{
    public class Coin : MonoBehaviour, IPickUp
    {
        [SerializeField] private int _nominal;
        [SerializeField] private float _rotateSpeed = 100f;

        public void PickUp(PlayerInstance player)
        {
            print("Picked up coin _nominal" +  _nominal);
            player.DataHandler.AddMoney(_nominal);
            
            Destroy(gameObject);
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);
        }
    }
}