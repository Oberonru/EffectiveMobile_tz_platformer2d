using UnityEngine;

namespace Core.Handlers
{
    public class AudioHandler : MonoBehaviour, IAudioHandler
    {
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;
        
        public void PlaySfx(AudioClip clip)
        {
            _sfxSource.PlayOneShot(clip);
        } 
        
        public void PlaySfx(AudioClip[] clip)
        {
            if (clip.Length == 0)
            {
                Debug.LogWarning("No clip given to PlaySfx");
                return;
            }
            
            var rnd = Random.Range(0, clip.Length);
            _sfxSource.PlayOneShot(clip[rnd]);
        }
        
        public void PlayMusic(AudioClip clip, bool isLooping)
        {
            _musicSource.clip = clip;
            _musicSource.loop = isLooping;
            _musicSource.Play();
        }

        public void StopMusic()
        {
            _musicSource.Stop();
        }
    }
}