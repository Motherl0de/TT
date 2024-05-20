using UnityEngine;
using UnityEngine.SceneManagement;

namespace TT
{
    public sealed class EnemyDie : MonoBehaviour
    {
        private void Update()
        {
            if (gameObject.GetComponentInChildren<HpEnemy>() is null)
            {
                SceneManager.LoadScene("Scenes/WinScene");
            }
        }
    }
}
