using System;
using Core.Items.SO;

namespace Core.Items.ItemObjects
{
    [Serializable]
    public class Item
    {
        public ScriptableItem ScriptableItem => _reference;
        private ScriptableItem _reference;

        public int Count { get;  }
        
        public Item(ScriptableItem scriptableItem)
        {
            _reference = scriptableItem;
            Count = 1;
        }

        public Item(ScriptableItem reference, int count)
        {
            _reference = reference;
            Count = count;
        }
    }
}