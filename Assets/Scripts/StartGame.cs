
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TT
{
    public sealed class StartGame : MonoBehaviour
    {
        public async UniTaskVoid StartScene()
        {
            await SceneManager.LoadSceneAsync("SampleScene");
        }
    }
}
