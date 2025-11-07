using Core.Configs.Audio;
using Core.Handlers;
using Core.Player;
using Infrastructure.SO;

namespace Core.Items.SO
{
    public abstract class ScriptablePickUpBehavior : ScriptableObjectIdentity
    {
        public abstract void Execute(PlayerInstance player, ScriptableItem item, IAudioHandler handler,
            AudioClipsConfig config);
    }
}