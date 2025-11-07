using Core.Items.ItemObjects;
using Core.Player;
using Infrastructure.SO;
using UnityEngine;

namespace Core.Items.SO
{
    [CreateAssetMenu(menuName = "Items/Item")]
    public class ScriptableItem : ScriptableObjectIdentity
    {
        [SerializeField] private ScriptablePickUpBehavior _scriptablePickUp;
        [SerializeField] private ItemType _type = ItemType.Weapon;
        [SerializeField] private int _price;
        [SerializeField] private int _amount;
        
        public ItemType Type => _type;
        public int Price => _price;
        public int Amount => _amount;
        public ScriptablePickUpBehavior Behavior => _scriptablePickUp;
        
        public Item CreateItem()
        {
            return new Item(this);
        }
    }
}