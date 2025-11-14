using Core.Configs.Audio;
using Core.Handlers;
using Core.Items.ItemObjects;
using Core.Items.SO;
using Core.Player;
using Infrastructure.Services;
using UnityEngine;

namespace Core.Items.Behaviors
{
    [CreateAssetMenu(menuName = "Items/Behavior/MoneyPickUpBehavior", fileName = "MoneyPickUpBehavior")]
    public class CoinPickUpBehavior : ScriptablePickUpBehavior
    {
        public override void Execute(PlayerInstance player,ItemObject io, ScriptableItem item, IAudioHandler handler,
            AudioClipsConfig config, StorageService storage)
        {
            if (item.Type == ItemType.Coin)
            {
                player.DataHandler.AddMoney(item.Amount);
            }

            else
            {
                Debug.Log("Not money");
            }


            handler?.PlaySfx(config.PickUpCoins);
        }
    }
}