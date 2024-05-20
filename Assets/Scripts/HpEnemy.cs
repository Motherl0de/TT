using System;
using UnityEngine;
using UnityEngine.UI;

namespace TT
{
    public sealed class HpEnemy : MonoBehaviour
    {
        private float _hpEnemy = 100f;
        [SerializeField] private Slider _sliderHp;

        private void Start()
        {
            if (PlayerPrefs.GetFloat("_hpEnemy") <= 0)
            {
                _hpEnemy = PlayerPrefs.GetFloat("_hpEnemy");
            }
            else { _hpEnemy = 100f; }
            PlayerPrefs.Save();
        }

        public void Damage(float damage)
        {
            _hpEnemy -= damage;
            PlayerPrefs.SetFloat("_hpEnemy",_hpEnemy - damage);
            if (_hpEnemy <= 0)
            {
                _sliderHp.value = 0f;
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            _sliderHp.value = _hpEnemy;
        }
    }
}
