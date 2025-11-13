using System;
using Core.Items.SO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UniRx;

namespace Core.Items.Views
{
    public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Image _inventoryIcon;
        [SerializeField] private TextMeshProUGUI _countText;

        public IObservable<InventorySlot> OnSlotDragStarted => _onSlotDragStarted;
        private Subject<InventorySlot> _onSlotDragStarted = new();

        private int _count = 1;
        private Transform _parentAfterDrag;

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public Transform ParentAfterDrag
        {
            get => _parentAfterDrag;
            set => _parentAfterDrag = value;
        }

        public ScriptableItem ScriptableItem => scriptableItem;
        private ScriptableItem scriptableItem;

        public void InitItem(ScriptableItem item)
        {
            scriptableItem = item;
            _inventoryIcon.sprite = item.Sprite;
            RefreshCount();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            var slot = GetComponentInParent<InventorySlot>();
            if (slot != null)
            {
                _onSlotDragStarted?.OnNext(slot); 
                slot.Select();                  
            }

            _inventoryIcon.raycastTarget = false;
            _parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var oldSlot = _parentAfterDrag.GetComponent<InventorySlot>();
            oldSlot?.Deselect();

            _inventoryIcon.raycastTarget = true;
            transform.SetParent(_parentAfterDrag);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void RefreshCount()
        {
            _countText.text = _count.ToString();
            _countText.gameObject.SetActive(_count > 1);
        }
    }
}