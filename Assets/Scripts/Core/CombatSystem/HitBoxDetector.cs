using System;
using Core.Enemies;
using UniRx;
using UnityEngine;

namespace Core.CombatSystem
{
    public class HitBoxDetector : MonoBehaviour
    {
        public IObservable<IHitBox> OnEnter => _onEnter;
        private Subject<IHitBox> _onEnter = new();

        public IObservable<IHitBox> OnStay => _onStay;
        private Subject<IHitBox> _onStay = new();

        public IObservable<IHitBox> OnExit => _onExit;
        private Subject<IHitBox> _onExit = new();

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHitBox box))
            {
                print("on trigger enter" + other.name);
                _onEnter.OnNext(box);
            }
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHitBox box))
            {
                _onStay.OnNext(box);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHitBox box))
            {
                print("on trigger exit" + other.name);

                _onExit.OnNext(box);
            }
        }
    }
}