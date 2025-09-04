using Interface;
using UnityEngine;

namespace Input
{
    public class PlayerInputSystem : IPlayerInput, System.IDisposable
    {
        private PlayerInputActions inputActions;

        public PlayerInputSystem()
        {
            inputActions = new PlayerInputActions();
            inputActions.Enable();
        }

        public float Horizontal => inputActions.Player.Move.ReadValue<Vector2>().x;
        public bool IsJumpPressed => inputActions.Player.Jump.WasPressedThisFrame();
        public bool IsJumpHold => inputActions.Player.JumpHold.ReadValue<float>() > 0f;
        public bool IsAttackPressed => inputActions.Player.Attack.WasReleasedThisFrame();
        public bool IsAttackHold => inputActions.Player.AttackHold.ReadValue<float>() > 0f;

        public void Dispose()
        {
            inputActions?.Dispose();
        }
    }
}