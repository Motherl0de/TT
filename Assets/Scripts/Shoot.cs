using System;
using TT.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TT
{
    public sealed class Shoot : MonoBehaviour
    {
        private bool _isActive;
        private PointEffect _pointer;
        private ParticleSystem _partical;
        [SerializeField] private InputAction _inputs;
        private ParticleSystem Partical => _partical ??= GetComponentInChildren<ParticleSystem>();
        private PointEffect Pointer => _pointer ??= GetComponentInChildren<PointEffect>();

        private void OnEnable()
        {
            _inputs.Enable();
            _inputs.performed += Attack;
        }

        private void Attack(InputAction.CallbackContext _)
        {
            AimMouse();
            Partical.Play();
        }

        private void OnDisable()
        {
            _inputs.Disable();
            _inputs.performed -= Attack;
        }

        private void AimMouse()
        {
            Ray ray = new Ray(transform.position, transform.right);//Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Debug.DrawRay(Pointer.transform.position, transform.right * 100f, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pointer.transform.position = hit.point;
                HpEnemy enemy = hit.collider.gameObject.GetComponentInChildren<HpEnemy>();
                if (enemy)
                {
                    enemy.Damage(25f);
                }
            }
        }
    }
}
