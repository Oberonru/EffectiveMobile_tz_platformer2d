using Core.Items.SO;
using Core.Items.Views;
using UniRx;
using UnityEngine;

namespace Core.Handlers
{
    public class InventoryHandler : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _slots;
        [SerializeField] private InventoryItem _inventoryPrefab;
        [SerializeField] private int _maxCellSize = 4;

        private InventorySlot _selectedSlot;

        private void Start()
        {
            _selectedSlot = null;
        }
        
        public void AddItem(ScriptableItem item)
        {
            for (var i = 0; i < _slots.Length; i++)
            {
                var slot = _slots[i];

                var inventoryItem = slot.GetComponentInChildren<InventoryItem>();
                if (inventoryItem != null && inventoryItem.ScriptableItem != null &&
                    inventoryItem.ScriptableItem == item && inventoryItem.ScriptableItem.IsStackable &&
                    inventoryItem.Count < _maxCellSize)
                {
                    inventoryItem.Count++;
                    inventoryItem.RefreshCount();
                }
            }

            for (var i = 0; i < _slots.Length; i++)
            {
                var slot = _slots[i];

                var itemInventory = slot.GetComponentInChildren<InventoryItem>();
                if (itemInventory == null)
                {
                    SpawnItem(item, slot);
                    return;
                }
            }
        }
        
        public void ChangeSelectedSlot(InventorySlot slot)
        {
            if (_selectedSlot != null)
                _selectedSlot.Deselect();

            slot.Select();
            _selectedSlot = slot;
        }

        private void SpawnItem(ScriptableItem item, InventorySlot slot)
        {
            var inventoryItem = Instantiate(_inventoryPrefab, slot.transform);
            inventoryItem.InitItem(item);

            inventoryItem.OnSlotDragStarted.Subscribe(ChangeSelectedSlot).AddTo(this);
        }
    }
}