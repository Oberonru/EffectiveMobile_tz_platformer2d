using Infrastructure.Configs;
using UnityEngine;

namespace Core.Configs.Audio
{
    [CreateAssetMenu(fileName = "AudioClipsConfig", menuName = "Configs/Audio/AudioClipsConfig")]
    public class AudioClipsConfig : ScriptableConfig
    {
        [SerializeField] private AudioClip[] _mainMenuClips;
        [SerializeField] private AudioClip[] _levelMusicClips;

        [SerializeField] private AudioClip[] _pickUpCoins;
        [SerializeField] private AudioClip _pickUpHeal;
        [SerializeField] private AudioClip[] _jumps;
        [SerializeField] private AudioClip _attack;

        public AudioClip[] MainMenuClips => _mainMenuClips;
        public AudioClip[] LevelMusicClips => _levelMusicClips;

        public AudioClip[] PickUpCoins => _pickUpCoins;
        public AudioClip PickUpHeal => _pickUpHeal;
        public AudioClip[] Jumps => _jumps;
        public AudioClip Attack => _attack;
    }
}