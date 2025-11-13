using System;
using Core.Items.SO;

namespace Core.Items.ItemObjects
{
    [Serializable]
    public class Item
    {
        private ScriptableItem _reference;
        private int _count;

        public Item(ScriptableItem scriptableItem,  int count)
        {
            _reference = scriptableItem;
            _count = count;
        }
    }
}