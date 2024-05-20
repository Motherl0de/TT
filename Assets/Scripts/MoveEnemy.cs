using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TT
{
    public sealed class MoveEnemy : MonoBehaviour
    {
        private Transform _playerPosition;

        private void Start()
        {
            _playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerPosition.position, 2f * Time.deltaTime);
            transform.LookAt(_playerPosition);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene("Scenes/loseScene");
            }
        }
    }
}
