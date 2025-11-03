using System;
using UnityEngine;
using UniRx;

namespace Core.BaseComponents
{
    public class HitBox : MonoBehaviour
    {
        public IObservable<HitBox> OnEnter => _onEnter;
        private Subject<HitBox> _onEnter = new();

        public IObservable<HitBox> OnStay => _onStay;
        private Subject<HitBox> _onStay = new();

        public IObservable<HitBox> OnExit => _onExit;
        private Subject<HitBox> _onExit = new();

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HitBox box))
            {
                _onEnter.OnNext(box);
            }
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out HitBox box))
            {
                _onStay.OnNext(box);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out HitBox box))
            {
                _onExit.OnNext(box);
            }
        }
    }
}