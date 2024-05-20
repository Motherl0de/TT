using System;
using UnityEngine;
using UnityEngine.UI;

namespace TT
{
    public sealed class HpEnemy : MonoBehaviour
    {
        private float HEnemy = 100f;
        [SerializeField] private Slider _sliderHp;

        private void Start()
        {
            if (PlayerPrefs.HasKey("HEnemy") && HEnemy > 0)
            {
                HEnemy = PlayerPrefs.GetFloat("HEnemy");
            }
            else { HEnemy = 100f; }
        }

        public void Damage(float damage)
        {
            HEnemy -= damage;
            PlayerPrefs.SetFloat("HEnemy",HEnemy);
            if (HEnemy <= 0)
            {
                _sliderHp.value = 0f;
                Destroy(gameObject);
                PlayerPrefs.DeleteKey("HEnemy");
            }
        }

        private void FixedUpdate()
        {
            _sliderHp.value = HEnemy;
        }
    }
}
