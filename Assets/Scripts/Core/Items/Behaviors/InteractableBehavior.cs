using Core.Configs.Audio;
using Core.Handlers;
using Core.Items.ItemObjects;
using Core.Items.SO;
using Core.Player;
using Infrastructure.Services;
using UniRx;
using UnityEngine;

namespace Core.Items.Behaviors
{
    [CreateAssetMenu(menuName = "Items/Behavior/InteractableBehavior", fileName = "InteractableBehavior")]
    public class InteractableBehavior : ScriptablePickUpBehavior
    {
        public override void Execute(PlayerInstance player, ItemObject io, ScriptableItem item, IAudioHandler handler,
            AudioClipsConfig config, StorageService storage)
        {
            player.PlayerController.InteractStream.Take(1).Subscribe(_ =>
            {
                player.DataHandler.AddItem(item);
                storage.Save();
                
                player.InventoryHandler.AddItem(item);
                Destroy(io.gameObject);
            }).AddTo(player);
        }
    }
}