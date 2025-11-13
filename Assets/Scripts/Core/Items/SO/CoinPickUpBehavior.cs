using Core.Configs.Audio;
using Core.Handlers;
using Core.Player;
using UnityEngine;

namespace Core.Items.SO
{
    [CreateAssetMenu(menuName = "Items/Behavior/CoinPickUpBehavior", fileName = "CoinPickUpBehavior")]
    public class CoinPickUpBehavior : ScriptablePickUpBehavior
    {
        public override void Execute(PlayerInstance player, ScriptableItem item, IAudioHandler handler,
            AudioClipsConfig config)
        {
            player.DataHandler.AddMoney(item.Amount);

            handler?.PlaySfx(config.PickUpCoins);
        }
    }
}