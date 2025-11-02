using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;
        
        public void SetMoney(int money)
        {
            _text.text = money.ToString();
        }
    }
}