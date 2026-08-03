using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Logic
{
    public class PlayerInput : PlayerComponent
    {
        [Header("Input Actions")]
        [field: SerializeField]
        public InputActionReference moveAction { get; private set; } //need Vector2
        [field: SerializeField]
        public InputActionReference jumpAction { get; private set; } //need Button
        
        
    }
}