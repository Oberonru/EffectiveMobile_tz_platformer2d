using Core.Gameplay;
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
        [Inject] private IScreenHandler _handler;
        [SerializeField] private WinZone _winZone;
        [SerializeField] private WinScreen _winScreen;

        private void OnValidate()
        {
            if (_winZone == null) _winZone = FindObjectOfType<WinZone>();
            if (_winScreen == null) _winScreen = FindObjectOfType<WinScreen>();
        }

        private void OnEnable()
        {
            _winZone.OnWin.Subscribe(player => Win(player)).AddTo(this);
        }

        private void Win(PlayerInstance player)
        {
            
        }
    }
}