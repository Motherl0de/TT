using System;
using TT.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TT
{
    public sealed class PlayerController : MonoBehaviour
    {
        private Inputs _inputAction;
        private float _speed = 0.3f;
        private Vector2 _moveVector;
        private Rigidbody _rigidbody;
        private Quaternion _currentRotation;
        private Vector3 _oldDirection = new Vector3();
        [SerializeField] private float _walkSpeed = 2f;
        [SerializeField] private float _runSpeed = 3f;

        private Rigidbody RB => _rigidbody ??= GetComponentInChildren<Rigidbody>();


        private void Awake()
        {
            _inputAction = new Inputs();
        }

        private void OnEnable()
        {
            _inputAction.Enable();
            _currentRotation = transform.rotation;
            _inputAction.Move.Jump.performed += OnJump;
            _inputAction.Move.Run.performed += OnRun;
            _inputAction.Move.Run.canceled += OnFinishRun;
        }
        private void OnFinishRun(InputAction.CallbackContext obj)
        {
            _speed = _walkSpeed;
        }

        private void OnRun(InputAction.CallbackContext obj)
        {
            _speed = _runSpeed;
        }

        private void FixedUpdate()
        {
            _moveVector = _inputAction.Move.WASD.ReadValue<Vector2>();
            var direction = new Vector3(_moveVector.x, 0f, _moveVector.y);
            _oldDirection = direction;
            transform.Translate(_oldDirection * _speed);
            _currentRotation = Quaternion.LookRotation(_oldDirection, Vector3.up);
            //_currentRotation = Quaternion.Lerp(_currentRotation, Quaternion.LookRotation(_oldDirection), Time.fixedDeltaTime * _speed);
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
