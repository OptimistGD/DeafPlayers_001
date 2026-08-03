using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Visual
{
    public class MonoPlayerMovement : MonoBehaviour
    {
        [Header("Input Actions")]
        [field: SerializeField]
        public InputActionReference moveAction { get; private set; } //need Vector2
        [field: SerializeField]
        public InputActionReference jumpAction { get; private set; } //need Button


        private void OnEnable()
        {
            moveAction.action.Enable();
            jumpAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
            jumpAction.action.Disable();
        }
        
    }
}