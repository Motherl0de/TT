using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TT.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TT
{
    public sealed class SpawnWeapon : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private InputAction _inputAction;
        [SerializeField] private Transform _transformSpawn;
        private GameObject _pref;
        private IEnumerable<SpawnWeapon> Weapons => FindObjectsOfType<SpawnWeapon>().Where(w => w != this);

        private void OnEnable()
        {
            _inputAction.Enable();
            _inputAction.performed += SpawnWeapons;
        }

        private void SpawnWeapons(InputAction.CallbackContext obj)
        {
            foreach (var weapon in Weapons)
            {
                weapon.Deselect();
            }

            if (_pref is null)
            {
                _pref = Instantiate(_weapon.Prefab, _transformSpawn);
            }
            else
            {
                _pref.SetActive(true);
            }
        }

        private void Deselect()
        {
            if (_pref is not null)
            {
                _pref.SetActive(false);
            }
        }

        private void OnDisable()
        {
            _inputAction.Disable();
            _inputAction.performed -= SpawnWeapons;
        }
    }
}
