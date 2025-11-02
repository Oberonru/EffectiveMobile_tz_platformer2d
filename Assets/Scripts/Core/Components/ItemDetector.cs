using System;
using UniRx;
using UnityEngine;

namespace Core.Components
{
    public class ItemDetector : MonoBehaviour
    {
        public IObservable<IPickUp> OnPickUp => _itemObject;
        private Subject<IPickUp> _itemObject = new();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPickUp pickUp))
            {
                _itemObject.OnNext(pickUp);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPickUp pickUp))
            {
            }
        }
    }
}