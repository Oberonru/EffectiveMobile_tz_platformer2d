using System;
using Core.Model;
using Infrastructure.Utils;
using UniRx;
using UnityEngine;

namespace Core.UI.Screens
{
    public class ScreenHandler : MonoBehaviour, IScreenHandler
    {
        public KeyValueList<ScreenType, UIScreen> Screens => _screens;
        [SerializeField] private KeyValueList<ScreenType, UIScreen> _screens;
        [SerializeField] private ScreenType _currentScreen;
        [SerializeField] private bool _setDefaultScreen;
        public IObservable<ScreenType> OnScreenChanged => _onScreenChanged;
        private Subject<ScreenType> _onScreenChanged;

        public ScreenType CurrentScreen => _currentScreen;

        private void Start()
        {
            foreach (var screen in _screens.Values)
            {
                screen.SetVisible(false);
            }

            if (_setDefaultScreen)
                SetScreen(_currentScreen);
        }

        public void SetScreen(ScreenType screenType)
        {
            var current = _screens[_currentScreen];
            current.SetVisible(false);
            _currentScreen = screenType;
            var newScreen = _screens[screenType];

            newScreen.SetVisible(true);

            _onScreenChanged?.OnNext(screenType);
        }

        public T GetScreen<T>(ScreenType type) where T : UIScreen
        {
            return _screens.TryGetValue(type, out var screen) ? screen as T : null;
        }
    }
}