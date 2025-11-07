using Core.Interfaces;
using Core.Items.SO;
using Core.Player;
using UnityEngine;

namespace Core.Items.ItemObjects
{
    public class ItemObject : MonoBehaviour, IPickUp
    {
        [SerializeField] private ScriptableItem _scriptableItem;
        
        public ScriptableItem ScriptableItem => _scriptableItem;
        
        public void PickUp(PlayerInstance player)
        {
            throw new System.NotImplementedException();
        }
    }
}