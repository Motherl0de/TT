using UnityEngine;

namespace TT
{
    public sealed class AttackPlayer : MonoBehaviour
    {
        private HpEnemy _enemy;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _enemy.Damage(25f);
            }
        }
    }
}
