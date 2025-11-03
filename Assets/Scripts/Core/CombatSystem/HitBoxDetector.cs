using System;
using UniRx;
using UnityEngine;

namespace Core.CombatSystem
{
    public class HitBoxDetector : MonoBehaviour
    {
        public IObservable<IHitBox> OnEnter => _onEnter;
        private Subject<HitBox> _onEnter = new();

        public IObservable<HitBox> OnStay => _onStay;
        private Subject<HitBox> _onStay = new();

        public IObservable<HitBox> OnExit => _onExit;
        private Subject<HitBox> _onExit = new();

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out HitBox box))
            {
                print("on trigger enter" + other.name);
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

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out HitBox box))
            {
                print("on trigger exit" + other.name);

                _onExit.OnNext(box);
            }
        }
    }
}