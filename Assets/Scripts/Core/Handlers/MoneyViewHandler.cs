using Core.Player;
using Core.UI;
using Core.UI.Views;
using UnityEngine;
using UniRx;

namespace Core.Handlers
{
    public class MoneyViewHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInstance _player;
        [SerializeField] private MoneyView _view;

        private void OnValidate()
        {
            if (_player == null) _player = FindObjectOfType<PlayerInstance>();
        }

        private void OnEnable()
        {
            _player.DataHandler.MoneyChanged.DistinctUntilChanged().Subscribe(money => { _view.SetMoney(money); })
                .AddTo(this);
        }
    }
}