using Infrastructure.Configs;
using UnityEngine;

namespace Core.Configs.Audio
{
    [CreateAssetMenu(
        menuName = "Configs/Audio/ButtonSoundConfig", fileName = "ButtonSoundConfig")]
    public class ButtonSoundConfig : ScriptableConfig
    {
        [SerializeField] private AudioClip _audioClip;
        
        public AudioClip Track => _audioClip;
    }
}