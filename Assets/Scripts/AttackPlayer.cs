using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TT
{
    public sealed class AttackPlayer : MonoBehaviour
    {
        private HpEnemy _enemy;

        private void Start()
        {
            _enemy = FindObjectOfType<HpEnemy>();
        }

        private void OnCollisionEnter([NotNull] Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _enemy.Damage(25f);
            }
        }
    }
}
