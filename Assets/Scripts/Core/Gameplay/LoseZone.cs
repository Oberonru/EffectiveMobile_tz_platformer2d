using System;
using Core.Player;
using UniRx;
using UnityEngine;

namespace Core.Gameplay
{
    public class LoseZone : MonoBehaviour
    {
        public IObservable<PlayerInstance> OnLose => _onLose;
        private Subject<PlayerInstance> _onLose = new();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerInstance>(out var player))
            {
                _onLose.OnNext(player);
            }
        }
    }
}