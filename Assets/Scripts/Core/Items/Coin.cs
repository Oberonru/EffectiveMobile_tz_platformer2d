using Core.Configs.Audio;
using Core.Handlers;
using Core.Interfaces;
using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Items
{
    public class Coin : MonoBehaviour, IPickUp
    {
        [Inject] private IAudioHandler _handler;
        [Inject] private AudioClipsConfig _config;
        
        [SerializeField] private int _nominal;
        [SerializeField] private float _rotateSpeed = 100f;

        public void PickUp(PlayerInstance player)
        {
            player.DataHandler.AddMoney(_nominal);
            _handler.PlaySfx(_config.PickUpCoins);
            
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