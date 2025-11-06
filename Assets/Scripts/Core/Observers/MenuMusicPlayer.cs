using Core.Configs.Audio;
using Core.Handlers;
using UnityEngine;
using Zenject;

namespace Core.Observers
{
    public class MenuMusicPlayer : MonoBehaviour
    {
        [Inject] private IAudioHandler _handler;
        [Inject] private AudioClipsConfig _config;

        private void Start()
        {
            _handler.PlayMusic(_config.MainMenuClip, true);
        }

        private void OnDisable()
        {
            _handler.StopMusic();
        }
    }
}