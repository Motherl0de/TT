using System;
using UnityEngine;

namespace TT
{
    public sealed class Shoot : MonoBehaviour
    {
        private bool _isActive;
        [SerializeField] private Transform _pointer;
        [SerializeField] private GameObject _bulletPref;

        void Update()
        {
            AimMouse();
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(_bulletPref, _pointer.transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody>().velocity = transform.right * 10f;
            }
        }

        private void AimMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Debug.DrawRay(_pointer.transform.position, transform.right * 100f, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _pointer.position = hit.point;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_isActive) return;
            _isActive = false;
            GetComponent<Rigidbody>().useGravity = true;
            HpEnemy enemy = other.gameObject.GetComponent<HpEnemy>();
            if (enemy)
            {
                enemy.Damage(25f);
            }
        }
    }
}
