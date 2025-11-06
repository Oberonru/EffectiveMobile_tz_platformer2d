using Core.Gameplay;
using Core.Model;
using Core.Player;
using Core.UI.Screens;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Handlers
{
    [RequireComponent(typeof(WindZone))]
    public class LevelStateHandler : MonoBehaviour
    {
        [Inject] private IScreenHandler _screenHandler;
        [SerializeField] private WinZone _winZone;

        private void OnValidate()
        {
            if (_winZone == null) _winZone = FindObjectOfType<WinZone>();
        }

        private void OnEnable()
        {
            _winZone.OnWin.
                Subscribe(player => Win(player)).
                AddTo(this);
        }

        private void Win(PlayerInstance player)
        {
            _screenHandler.SetScreen(ScreenType.WinScreen);
        }
    }
}