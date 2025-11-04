using Core.Player;
using Core.UI;
using UnityEngine;
using UniRx;

namespace Core.Handlers
{
    public class MoneyViewHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInstance _player;
        [SerializeField] private MoneyView _view;

        private void OnEnable()
        {
            _player.DataHandler.MoneyChanged.DistinctUntilChanged().
                Subscribe(money =>
                {
                    _view.SetMoney(money);
                }).
                AddTo(this);
        }
    }
}