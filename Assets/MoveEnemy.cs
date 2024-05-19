using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TT
{
    public sealed class MoveEnemy : MonoBehaviour
    {
        private Transform _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, 2f * Time.deltaTime);
        }

        // private async void OnCollisionEnter(Collision other)
        // {
        //     if (other.gameObject.CompareTag("Player"))
        //     {
        //         Destroy(_player.gameObject);
        //         await UniTask.Delay(300);
        //         //Lose menu
        //     }
        // }
    }
}
