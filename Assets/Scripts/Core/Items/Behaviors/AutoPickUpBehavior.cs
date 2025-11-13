using Core.Configs.Audio;
using Core.Handlers;
using Core.Items.ItemObjects;
using Core.Items.SO;
using Core.Player;
using UnityEngine;

namespace Core.Items.Behaviors
{
    [CreateAssetMenu(menuName = "Items/Behavior/AutoPickUpBehavior", fileName = "AutoPickUpBehavior")]

    public class AutoPickUpBehavior : ScriptablePickUpBehavior
    {
        public override void Execute(PlayerInstance player, ItemObject io, ScriptableItem item, IAudioHandler handler, AudioClipsConfig config)
        {
            player.InventoryHandler.AddItem(item);
            
            Destroy(io.gameObject);
        }
    }
}