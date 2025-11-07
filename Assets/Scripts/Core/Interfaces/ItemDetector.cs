using System;
using UniRx;
using UnityEngine;

namespace Core.Interfaces
{
    public class ItemDetector : MonoBehaviour
    {
        public IObservable<IPickUp> OnEnter => _onEnter;
        private Subject<IPickUp> _onEnter = new();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPickUp pickUp))
            {
                _onEnter.OnNext(pickUp);
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