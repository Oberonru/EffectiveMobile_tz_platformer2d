using Core.Player;
using Core.UI.Screens.Data;
using Infrastructure.Services;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.UI.Screens
{
    public class WinScreen : UIScreen
    {
        [Inject] private StorageService _storage;
        [Inject] private SceneLoaderService _loader;
        [SerializeField] private PlayerInstance _player;

        [SerializeField] private Button _nextLevel;
        [SerializeField] private Button _menu;
        [SerializeField] private TextMeshProUGUI _heading;
        [SerializeField] private TextMeshProUGUI _moneyReciewed;
        [SerializeField] private TextMeshProUGUI _moneyReciewedValue;
        [SerializeField] private TextMeshProUGUI _hardMoneyReciewed;
        [SerializeField] private TextMeshProUGUI _hardMoneyReciewedValue;
        [SerializeField] private TextMeshProUGUI _itemReciewed;
        [SerializeField] private TextMeshProUGUI _itemReciewedValue;
        [SerializeField] private TextMeshProUGUI _sessionTimee;
        [SerializeField] private TextMeshProUGUI _sessionTimeValue;

        private void OnEnable()
        {
            _nextLevel?.onClick.
                AsObservable().
                Subscribe(_ => _loader.LoadScene(SceneName.Level2.ToString())).
                AddTo(this);
            
            _menu?.onClick.
                AsObservable().
                Subscribe(_ => _loader.LoadScene(SceneName.MainMenu.ToString())).
                AddTo(this);
        }

        public void ShowLevelResult()
        {
            _heading.text = "Уровень пройден - поехали дальше!";
            _moneyReciewed.text = "Очков собрано";
            _moneyReciewedValue.text = _storage.GameData.PlayerData.PlayerMoney.ToString();
            _hardMoneyReciewed.text = "Кристалов заработано";
            _hardMoneyReciewedValue.text = "//TODO: заглушка";
            _itemReciewed.text = "Предметов собрано";
            _itemReciewedValue.text = "//TODO: заглушка";
            _sessionTimee.text = "Время";
            _sessionTimeValue.text = Time.timeSinceLevelLoad.ToString();
        }
    }
}