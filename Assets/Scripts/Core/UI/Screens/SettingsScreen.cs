using Core.Model;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.UI.Screens
{
    public class SettingsScreen : UIScreen
    {
        [Inject] private IScreenHandler _handler;
        [SerializeField] private Button _back;

        private void OnEnable()
        {
            _back.onClick.
                AsObservable().
                Subscribe(_ => _handler.SetScreen(ScreenType.MainMenu)).
                AddTo(this);
        }
    }
}