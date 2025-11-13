using Core.Configs.Audio;
using Core.Handlers;
using Core.Interfaces;
using Core.Items.SO;
using Core.Player;
using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Core.Items.ItemObjects
{
    public class ItemObject : MonoBehaviour, IPickUp
    {
        [Inject] private IAudioHandler _handler;
        [Inject] private AudioClipsConfig _config;
        [Inject] private StorageService _storage;
        [SerializeField] private SpriteRenderer _itemIcon;
        [SerializeField] private ScriptableItem _scriptableItem;
        public ScriptableItem ScriptableItem => _scriptableItem;

        private void Start()
        {
            _itemIcon.sprite = _scriptableItem.Sprite;
        }

        public void PickUp(PlayerInstance player)
        {
            _scriptableItem.Behavior.Execute(player, this, _scriptableItem, _handler, _config, _storage);
        }
    }
}