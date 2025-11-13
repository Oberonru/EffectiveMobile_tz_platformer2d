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

        private readonly Subject<InventorySlot> _onSlotDragStarted = new();
        public IObservable<InventorySlot> OnSlotDragStarted => _onSlotDragStarted;

        private int _count = 1;
        private Transform _parentAfterDrag;
        private ScriptableItem _scriptableItem;

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        private void Start()
        {
            _countText.raycastTarget = false;
        }

        public Transform ParentAfterDrag
        {
            get => _parentAfterDrag;
            set => _parentAfterDrag = value;
        }

        public ScriptableItem ScriptableItem => _scriptableItem;

        public void InitItem(ScriptableItem item)
        {
            _scriptableItem = item;
            _inventoryIcon.sprite = item.Sprite;
            RefreshCount();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            var slot = GetComponentInParent<InventorySlot>();
            if (slot != null)
            {
                _onSlotDragStarted.OnNext(slot);
            }

            _inventoryIcon.raycastTarget = false;
            _parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // убран вызов oldSlot?.Deselect()
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
