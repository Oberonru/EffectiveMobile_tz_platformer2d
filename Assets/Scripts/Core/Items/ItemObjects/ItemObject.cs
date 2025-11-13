using Core.Interfaces;
using Core.Items.SO;
using Core.Player;
using UnityEngine;

namespace Core.Items.ItemObjects
{
    public class ItemObject : MonoBehaviour, IPickUp
    {
        [SerializeField] private ScriptableItem _scriptableItem;
        [SerializeField] private SpriteRenderer _itemIcon;
        public ScriptableItem ScriptableItem => _scriptableItem;

        private void Start()
        {
            _itemIcon.sprite = _scriptableItem.Sprite;
        }

        public void PickUp(PlayerInstance player)
        {
            player.InventoryHandler.AddItem(_scriptableItem);
            _scriptableItem.Behavior.Execute(player, _scriptableItem, null, null);
            
            Destroy(gameObject);
        }
    }
}