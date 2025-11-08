using System.Collections.Generic;
using System.Linq;
using Core.Items.SO;
using Infrastructure.DB;
using UnityEngine;

namespace Core.Items
{
    [CreateAssetMenu(menuName = "Items/Repository/ItemsRepository", fileName = "ItemsRepository")]
    public class ItemsRepository : ScriptableRepository
    {
        [SerializeField] private ScriptableItem[] _items;

        private Dictionary<string, ScriptableItem> _map = new();

        private void OnEnable()
        {
            _map = _items.ToDictionary(el => el.GUID, el => el);
        }
        
        public ScriptableItem GetItemById(string guid)
        {
            return _map.GetValueOrDefault(guid);
        }
    }
}