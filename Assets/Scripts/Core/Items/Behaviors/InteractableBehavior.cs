using Core.Configs.Audio;
using Core.Handlers;
using Core.Items.ItemObjects;
using Core.Items.SO;
using Core.Player;

namespace Core.Items.Behaviors
{
    public class InteractableBehavior : ScriptablePickUpBehavior
    {
        public override void Execute(PlayerInstance player, ItemObject io, ScriptableItem item, IAudioHandler handler, AudioClipsConfig config)
        {
        }
    }
}