using System;
using TT.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TT
{
    public sealed class SpawnWeapon : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private InputAction _inputAction;
        private GameObject _prefab;

        private void Awake()
        {
            _prefab = _weapon.Prefab;
        }

        private void OnEnable()
        {
            _inputAction.Enable();
            _inputAction.performed += OnDown;
        }

        private void OnDown(InputAction.CallbackContext obj)
        {
            Debug.Log(_prefab.name);
        }

        private void OnDisable()
        {
            _inputAction.Disable();
            _inputAction.performed -= OnDown;
        }
    }
}
