using Core.Configs.Audio;
using Core.Handlers;
using UnityEngine;
using Zenject;

namespace Core.Observers
{
    public class LevelMusicController : MonoBehaviour
    {
        [Inject] private IAudioHandler _handler;
        [Inject] private AudioClipsConfig _config;

        private void Start()
        {
            _handler.PlayMusic(_config.LevelMusicClip, true);
        }
    }
}