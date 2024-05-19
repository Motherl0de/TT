using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TT
{
    public sealed class CheckMenuButton : MonoBehaviour
    {
        public void CheckOnMainMenu()
        {
            SceneManager.LoadSceneAsync("Scenes/MenuScene");
        }
    }
}
