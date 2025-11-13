using Core.Interfaces;
using Core.Items.SO;
using Core.Player;
using UnityEngine;

namespace Core.Items.ItemObjects
{
    public class ItemObject : MonoBehaviour, IPickUp
    {
        [SerializeField] private SpriteRenderer _itemIcon;
        [SerializeField] private ScriptableItem _scriptableItem;
        public ScriptableItem ScriptableItem => _scriptableItem;

        private void Start()
        {
            _itemIcon.sprite = _scriptableItem.Sprite;
        }

        public void PickUp(PlayerInstance player)
        {
            _scriptableItem.Behavior.Execute(player, this, _scriptableItem, null, null);
        }
    }
}