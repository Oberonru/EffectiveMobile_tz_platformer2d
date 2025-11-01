using UnityEngine;

namespace Core.InputService
{
    public class DesktopInput : IInputService
    {
        public Vector2 InputAxis()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public bool JumpPressed()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public bool AttackPressed()
        {
            return Input.GetMouseButton(0);
        }
    }
}