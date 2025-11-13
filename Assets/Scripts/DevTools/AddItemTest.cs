using Core.Handlers;
using Core.Items.SO;
using Core.Player.Components;
using UnityEngine;

namespace DevTools
{
    public class AddItemTest : MonoBehaviour
    {
        [SerializeField] private InventoryHandler _handler;
        [SerializeField] private ScriptableItem _itemPrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                print("M");
                _handler.AddItem(_itemPrefab);
            }
        }
    }
}