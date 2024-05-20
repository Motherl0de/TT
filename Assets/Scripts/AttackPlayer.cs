using UnityEngine;

namespace TT
{
    public sealed class AttackPlayer : MonoBehaviour
    {
        private HpEnemy _enemy;
        private float _playerHp = 10f;

        private void Start()
        {
            _enemy = FindObjectOfType<HpEnemy>();
        }

        public void PlayerHp(float hp)
        {
            _playerHp = hp;
            if (_playerHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
