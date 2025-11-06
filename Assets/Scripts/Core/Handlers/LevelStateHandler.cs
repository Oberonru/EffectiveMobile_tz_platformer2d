using System.Runtime.InteropServices;
using Core.Configs.Audio;
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
        [Inject] private IAudioHandler _audioHandler;
        [Inject] private AudioClipsConfig _audioClipsConfig;
        [Inject] private IScreenHandler _handler;
        [SerializeField] private WinZone _winZone;
        [SerializeField] private LoseZone _loseZone;

        private void OnValidate()
        {
            if (_winZone == null) _winZone = FindObjectOfType<WinZone>();
        }

        private void OnEnable()
        {
            _winZone.OnWin.
                Subscribe(player => Win(player)).
                AddTo(this);
            
            _loseZone.OnLose.
                Subscribe(player => Lose(player)).
                AddTo(this);
        }

        private void Win(PlayerInstance player)
        {
            _handler.SetScreen(ScreenType.WinScreen);
            var screen = _handler.GetScreen<WinScreen>(ScreenType.WinScreen);
            
            screen.ShowLevelResult();
            player.StateHandler.DisableAllComponents();
        }

        private void Lose(PlayerInstance player)
        {
            _handler.SetScreen(ScreenType.LoseScreen);
            player.StateHandler.DisableAllComponents();
            _audioHandler.StopMusic();
            _audioHandler.PlaySfx(_audioClipsConfig.GameOver);
        }
    }
}