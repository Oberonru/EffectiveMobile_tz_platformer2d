using Core.Configs.Audio;
using Core.Handlers;
using UnityEngine;
using Zenject;

namespace Core.Audio
{
    public enum ClipType
    {
        Menu,
        Level,
    }

    public class MusicPlayer : MonoBehaviour
    {
        [Inject] private IAudioHandler _handler;
        [Inject] private AudioClipsConfig _config;

        [SerializeField] private ClipType _clipType = ClipType.Menu;

        private void Start()
        {
            SwitchMusic();
        }

        private void OnDisable()
        {
            _handler.StopMusic();
        }

        private void SwitchMusic()
        {
            if (_clipType == ClipType.Menu)
            {
                _handler.PlayMusic(_config.MainMenuClip, true);
            }

            if (_clipType == ClipType.Level)
            {
                _handler.PlayMusic(_config.LevelMusicClip, true);
            }
        }
    }
}