using Core.Player;
using UnityEngine;

namespace DevTools
{
    public class HealthViewTest : MonoBehaviour
    {
        [SerializeField] private PlayerInstance _player;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                print("TakeDamage");
                //_player.Health.TakeDamage(1);
            }
        }
    }
}