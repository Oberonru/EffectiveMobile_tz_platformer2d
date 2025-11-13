using Core.Player.Components;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Items.Views
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private Image _inventoryIcon;
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _notSelectedColor;

        private InventoryHandler _handler;

        private void Awake()
        {
            _handler = FindObjectOfType<InventoryHandler>();
            Deselect();
        }

        public void Select() => _inventoryIcon.color = _selectedColor;
        public void Deselect() => _inventoryIcon.color = _notSelectedColor;

        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount == 0)
            {
                var inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
                inventoryItem.ParentAfterDrag = transform;
                
                _handler.SelectSlot(this);
            }
        }
    }
}