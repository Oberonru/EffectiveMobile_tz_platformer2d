using System;
using Core.Items.SO;

namespace Core.Items.ItemObjects
{
    [Serializable]
    public class Item
    {
        private ScriptableItem _reference;

        public Item(ScriptableItem scriptableItem)
        {
            _reference = scriptableItem;
        }
    }
}