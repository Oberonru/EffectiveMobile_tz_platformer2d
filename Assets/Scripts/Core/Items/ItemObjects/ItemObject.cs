using Core.Configs.Audio;
using Core.Handlers;
using Core.Interfaces;
using Core.Items.SO;
using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Items.ItemObjects
{
    public class ItemObject : MonoBehaviour, IPickUp
    {
        [Inject] private IAudioHandler _handler;
        [Inject] private AudioClipsConfig _config;
        [SerializeField] private ScriptableItem _scriptableItem;
        
        public void PickUp(PlayerInstance player)
        {
            _scriptableItem.Behavior.
                Execute(player, _scriptableItem, _handler, _config, gameObject);
        }
    }
}