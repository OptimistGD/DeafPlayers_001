using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Logic
{
    public partial class PlayerController : MonoBehaviour
    {
        public Vector3 Direction
        {
            get
            {
                if (TryGetFirstComponent<PlayerControls>(out var playerControls))
                {
                    var direction2D = playerControls.GetInputDirection();
                    return new Vector3(direction2D.x, 0, direction2D.y);
                }
                
                return Vector3.zero;
            }
        }
    }
}
