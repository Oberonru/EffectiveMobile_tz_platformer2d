using System.Collections.Generic;
using System.Linq;
using Core.Items.ItemObjects;

namespace Core.Player.Model
{
    public class Inventory
    {
        public List<Item> InventoryItems = new();

        public void AddItem(Item item)
        {
            InventoryItems.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (InventoryItems.Contains(item))
            {
                InventoryItems.Remove(item);
            }
        }

        public Item FindItemById(string id)
        {
         return InventoryItems.FirstOrDefault(el => el.ScriptableItem.GUID == id);
        }
    }
}