using Core.Configs.Audio;
using Core.Handlers;
using Core.Items.ItemObjects;
using Core.Items.SO;
using Core.Player;
using Infrastructure.SO;

namespace Core.Items.Behaviors
{
    public abstract class ScriptablePickUpBehavior : ScriptableObjectIdentity
    {
        public abstract void Execute(PlayerInstance player,ItemObject io, ScriptableItem item, IAudioHandler handler,
            AudioClipsConfig config);
    }
}