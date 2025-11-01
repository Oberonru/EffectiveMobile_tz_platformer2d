using UnityEngine;

namespace Core.InputService
{
    public interface IInputService
    {
        Vector2 InputAxis();
        bool JumpPressed();
        bool AttackPressed();
    }
}