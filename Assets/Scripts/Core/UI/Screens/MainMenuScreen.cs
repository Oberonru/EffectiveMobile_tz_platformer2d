using Core.Model;
using Core.UI.Screens.Data;
using Infrastructure.Services;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.UI.Screens
{
    public class MainMenuScreen : UIScreen
    {
        [Inject] private IScreenHandler _handler;
        [Inject] private SceneLoaderService _loader;
        
        [SerializeField] private Button _play;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _exit;
        
        private void OnEnable()
        {
            _play.onClick.
                AsObservable().
                Subscribe(_ => _loader.LoadScene(SceneName.Level1.ToString())).
                AddTo(this);

            _settings.onClick.
                AsObservable().
                Subscribe(_ => _handler.SetScreen(ScreenType.Settings)).
                AddTo(this);

            _exit.onClick.
                AsObservable().
                Subscribe(_ => Exit()).
                AddTo(this);
        }

        private void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}