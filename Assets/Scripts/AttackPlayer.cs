using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene("Scenes/loseScene");
            }
        }

        private void OnCollisionEnter([NotNull] Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _enemy.Damage(25f);
                if (_enemy is null)
                {
                    SceneManager.LoadScene("Scenes/WinScene");
                }
            }
        }
    }
}
