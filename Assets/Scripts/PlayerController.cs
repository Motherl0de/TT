using System;
using TT.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TT
{
    public sealed class PlayerController : MonoBehaviour
    {
        private Inputs _inputAction;
        private Vector2 _moveVector = Vector2.zero;
         private Rigidbody _rigidbody;
         private Rigidbody RB => _rigidbody ??= GetComponentInChildren<Rigidbody>();

        private void OnEnable()
        {
            _inputAction.Enable();
        }

        private void Awake()
        {
            _inputAction = new Inputs();
            _inputAction.Move.WASD.performed += OnMove;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            var imoveVector = _inputAction.Move.WASD.ReadValue<Vector2>() * 1f;
            RB.velocity = new Vector3(imoveVector.x * 7f, 0f,imoveVector.y * 10f);
        }

        private void OnJump(InputAction.CallbackContext context)
        {

        }

        private void OnDisable()
        {
            _inputAction.Disable();
            _inputAction.Move.WASD.performed -= OnMove;
        }
    }
}
