using Core.Player;
using Core.UI.Views;
using UniRx;
using UnityEngine;

namespace Core.Handlers
{
    public class ItemsViewHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInstance _player;
        [SerializeField] private ItemsView _view;

        private void OnEnable()
        {
            _player.DataHandler.OnInventoryChanged.Subscribe(data =>
            {
                var item = data.Item1;
                var amount = data.Item2;
                
                _view.SetItem($"{amount}");
            }).AddTo(this);
        }
        
        
    }
}