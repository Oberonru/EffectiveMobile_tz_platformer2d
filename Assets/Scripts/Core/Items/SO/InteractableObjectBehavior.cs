using Core.Configs.Audio;
using Core.Handlers;
using Core.Player;
using UniRx;
using UnityEngine;

namespace Core.Items.SO
{
    [CreateAssetMenu(menuName = "Items/Behavior/InteractableObjectBehavior", fileName = "InteractableObjectBehavior")]

    public class InteractableObjectBehavior : ScriptablePickUpBehavior
    {
        public override void Execute(PlayerInstance player, ScriptableItem item, IAudioHandler handler, AudioClipsConfig config, GameObject gameObject)
        {
            player.PlayerController.InteractStream.
                Where(value => value > 0).
                Subscribe(
                    _ =>
                    {
                        player.DataHandler.AddItem(item.CreateItem(), 1);
                        
                        Destroy(gameObject);
                    }).AddTo(gameObject);
        }
    }
}