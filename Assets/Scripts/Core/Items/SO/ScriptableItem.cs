using Core.Items.Behaviors;
using Core.Items.ItemObjects;
using Infrastructure.SO;
using UnityEngine;

namespace Core.Items.SO
{
    [CreateAssetMenu(menuName = "Items/ScriptableItem")]
    public class ScriptableItem : ScriptableObjectIdentity
    {
        [SerializeField] private ScriptablePickUpBehavior _scriptablePickUp;
        [SerializeField] private ItemType _type = ItemType.Weapon;
        [SerializeField] private int _price;
        [SerializeField] private int _amount;
        [SerializeField] private Sprite sprite;
        [SerializeField] private bool _isStackable;
        
        public ScriptablePickUpBehavior Behavior => _scriptablePickUp;
        public ItemType Type => _type;
        public int Price => _price;
        public int Amount => _amount;
        public Sprite Sprite => sprite;
        public bool IsStackable => _isStackable;
        
        public Item CreateItem(int count)
        {
            return new Item(this, count);
        }
    }
}