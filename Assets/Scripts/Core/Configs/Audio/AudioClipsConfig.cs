using Infrastructure.Configs;
using UnityEngine;

namespace Core.Configs.Audio
{
    [CreateAssetMenu(fileName = "AudioClipsConfig", menuName = "Configs/Audio/AudioClipsConfig")]
    public class AudioClipsConfig : ScriptableConfig
    {
        [SerializeField] private AudioClip _mainMenuClip;
        [SerializeField] private AudioClip _levelMusicClip;

        [SerializeField] private AudioClip[] _pickUpCoins;
        [SerializeField] private AudioClip _pickUpHeal;
        [SerializeField] private AudioClip[] _jumps;
        [SerializeField] private AudioClip _attack;
        [SerializeField] private AudioClip _gameOver;
        [SerializeField] private AudioClip _winSound;

        public AudioClip MainMenuClip => _mainMenuClip;
        public AudioClip LevelMusicClip => _levelMusicClip;
        
        public AudioClip[] PickUpCoins => _pickUpCoins;
        public AudioClip PickUpHeal => _pickUpHeal;
        public AudioClip[] Jumps => _jumps;
        public AudioClip Attack => _attack;
        public AudioClip GameOver => _gameOver;
        public AudioClip WinSound => _winSound;
    }
}