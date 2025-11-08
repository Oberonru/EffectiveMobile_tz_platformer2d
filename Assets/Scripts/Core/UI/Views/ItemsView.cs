using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Views
{
    public class ItemsView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;
        
        public void SetItem(string text)
        {
            _text.text = text;
        }
    }
}