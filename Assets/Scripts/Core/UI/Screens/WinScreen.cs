using Core.Player;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.UI.Screens
{
    public class WinScreen : UIScreen
    {
        [Inject] private StorageService _storage;
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

        public void ShowLevelResult()
        {
            _hardMoneyReciewedValue.text = _storage.GameData.PlayerData.PlayerMoney.ToString();
        }
    }
}