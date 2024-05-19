
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TT
{
    public sealed class StartGame : MonoBehaviour
    {
        public void StartScene()
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
    }
}
