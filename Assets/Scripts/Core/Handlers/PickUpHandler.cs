using Core.Player;
using UniRx;
using UnityEngine;

namespace Core.Handlers
{
    public class PickUpHandler :  MonoBehaviour
    {
       [SerializeField] private PlayerInstance  _player;

       private void OnValidate()
       {
           if (_player == null) _player = FindObjectOfType<PlayerInstance>();
       }

       private void OnEnable()
       {
           _player.ItemDetector.OnPickUp.
               DistinctUntilChanged().
               Where(item => item != null && _player != null).
               Subscribe(item => item.PickUp(_player)).
               AddTo(this);
       }
    }
}