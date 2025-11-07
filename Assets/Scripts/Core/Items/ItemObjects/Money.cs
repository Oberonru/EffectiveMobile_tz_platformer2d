using Core.Configs.Audio;
using Core.Handlers;
using Core.Interfaces;
using Core.Items.SO;
using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Items.ItemObjects
{
    public class Money : MonoBehaviour, IPickUp
    {
        [Inject] private IAudioHandler _handler;
        [Inject] private AudioClipsConfig _config;
        [SerializeField] private ScriptableItem _scriptableItem;
        [SerializeField] private float _rotateSpeed = 100f;

        private void Update()
        {
            Rotate();
        }

        public void PickUp(PlayerInstance player)
        {
            _scriptableItem.Behavior.Execute(player, _scriptableItem, _handler, _config);
            Destroy(gameObject);
        }

        private void Rotate()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);
        }
    }
}