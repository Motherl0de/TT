using UnityEngine;
using UnityEngine.UI;

namespace TT
{
    public sealed class HpEnemy : MonoBehaviour
    {
        private float _hpEnemy = 100f;
        [SerializeField] private Slider _sliderHp;

        public void Damage(float damage)
        {
            _hpEnemy -= damage;
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
