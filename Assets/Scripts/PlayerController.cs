using System;
using TT.Input;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TT
{
    public sealed class PlayerController : MonoBehaviour
    {
        private Inputs _inputAction;
        private bool _isGrounded;
        private float _speed = 3f;
        private Vector2 _moveVector;
        private Rigidbody _rigidbody;
         private Rigidbody RB => _rigidbody ??= GetComponentInChildren<Rigidbody>();

        private void OnEnable()
        {
            _inputAction.Enable();
        }

        private void Awake()
        {
            _inputAction = new Inputs();
            _inputAction.Move.Jump.performed += OnJump;
            _inputAction.Move.Run.performed += OnRun;
            _inputAction.Move.Run.canceled += OnFinishRun;
        }

        private void OnFinishRun(InputAction.CallbackContext obj)
        {
            _speed = 3f;
        }

        private void OnRun(InputAction.CallbackContext obj)
        {
            _speed = 9f;
        }

        private void Update()
        {
            _moveVector = _inputAction.Move.WASD.ReadValue<Vector2>() * _speed;
            var direction = new Vector3(_moveVector.x, 0f, _moveVector.y);
            RB.AddForce(direction);
            RB.MoveRotation(Quaternion.LookRotation(direction));
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            RB.velocity = new Vector3(0f, 5f, 0f);
        }

        private void OnDisable()
        {
            _inputAction.Disable();
            _inputAction.Move.Jump.performed -= OnJump;
            _inputAction.Move.Run.performed -= OnRun;
            _inputAction.Move.Run.canceled -= OnFinishRun;
        }
    }
}
