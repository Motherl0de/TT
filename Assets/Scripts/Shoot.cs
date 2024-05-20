using System;
using UnityEngine;
using UnityEngine.UI;

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
                GameObject bullet = Instantiate(_bulletPref, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody>().velocity = transform.right * 20f;
            }
        }

        private void AimMouse()
        {
            Ray ray = new Ray(transform.position, transform.forward);//Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Debug.DrawRay(_pointer.transform.position, transform.right * 100f, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _pointer.position = hit.point;
            }

            HpEnemy enemy = hit.collider.gameObject.GetComponent<HpEnemy>();
            if (enemy)
            {
                enemy.Damage(25f);
            }
        }
    }
}
