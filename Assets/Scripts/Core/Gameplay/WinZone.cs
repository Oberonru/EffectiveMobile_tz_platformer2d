using System;
using Core.Player;
using UnityEngine;
using UniRx;

namespace Core.Gameplay
{
    public class WinZone : MonoBehaviour
    {
        public IObservable<PlayerInstance> OnWin => _onWin;
        private Subject<PlayerInstance> _onWin => new();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerInstance>(out var player))
            {
                _onWin.OnNext(player);
            }
        }
    }
}