using System;
using UnityEngine;
using UniRx;
using Core.Items.SO;
using Core.Items.Views;

namespace Core.Player.Components
{
    public class InventoryHandler : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _slots;
        [SerializeField] private InventoryItem _inventoryPrefab;
        [SerializeField] private int _maxCellSize = 4;

        private InventorySlot _selectedSlot;
        private InventoryItem _selectedItem;

        private readonly Subject<InventorySlot> _onSlotSelected = new();
        public IObservable<InventorySlot> OnSlotSelected => _onSlotSelected;

        private readonly Subject<ScriptableItem> _onItemAdded = new();
        public IObservable<ScriptableItem> OnItemAdded => _onItemAdded;

        private void Start()
        {
            _selectedSlot = null;
            _selectedItem = null;

            OnSlotSelected.Subscribe(ChangeSelectedSlot).AddTo(this);
        }


        public bool AddItem(ScriptableItem item)
        {
            if (item == null) return false;

            foreach (var slot in _slots)
            {
                var inventoryItem = slot.GetComponentInChildren<InventoryItem>();
                if (inventoryItem != null &&
                    inventoryItem.ScriptableItem == item &&
                    inventoryItem.ScriptableItem.IsStackable &&
                    inventoryItem.Count < _maxCellSize)
                {
                    inventoryItem.Count++;
                    inventoryItem.RefreshCount();

                    _onItemAdded.OnNext(item);
                    return true;
                }
            }

            foreach (var slot in _slots)
            {
                var inventoryItem = slot.GetComponentInChildren<InventoryItem>();
                if (inventoryItem == null)
                {
                    SpawnItem(item, slot);
                    _onItemAdded.OnNext(item);
                    return true;
                }
            }

            return false;
        }

        private void SpawnItem(ScriptableItem item, InventorySlot slot)
        {
            var inventoryItem = Instantiate(_inventoryPrefab, slot.transform);
            inventoryItem.InitItem(item);

            inventoryItem.OnSlotDragStarted
                .Subscribe(_onSlotSelected.OnNext)
                .AddTo(this);
        }

        public void SelectSlot(InventorySlot slot)
        {
            _onSlotSelected.OnNext(slot);
        }

        private void ChangeSelectedSlot(InventorySlot slot)
        {
            if (_selectedSlot != null)
                _selectedSlot.Deselect();

            _selectedSlot = slot;
            _selectedSlot.Select();

            _selectedItem = _selectedSlot.GetComponentInChildren<InventoryItem>();
        }

        public ScriptableItem GetSelectedItem()
        {
            return _selectedItem != null ? _selectedItem.ScriptableItem : null;
        }
    }
}