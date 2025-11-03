using UnityEngine;

namespace Core.Handlers
{
    public interface IAudioHandler
    {
        void PlaySfx(AudioClip clip);
        void PlaySfx(AudioClip[] clip);
        void PlayMusic(AudioClip clip, bool isLooping);
        void StopMusic();
    }
}