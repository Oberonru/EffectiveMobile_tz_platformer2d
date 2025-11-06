using Core.Configs.Audio;
using Core.Handlers;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Audio
{
    public class ButtonClickSound : MonoBehaviour
    {
        [Inject] private IAudioHandler _audioHandler;
        [Inject] private ButtonSoundConfig _config;

        [SerializeField] private Button _button; 
 
        private void OnEnable()
        {
            _button.onClick.
                AsObservable().
                Subscribe(_ => _audioHandler.PlaySfx(_config.Track) ).
                AddTo(this);
        }

        private void OnValidate()
        {
            if (_button is null) _button = GetComponent<Button>();
        }
    }
}