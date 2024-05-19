using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TT
{
    public sealed class WinAndLoseScene : MonoBehaviour
    {
        private Button _buttonWin;
        private Button ButtonWin => _buttonWin ??= GetComponent<Button>();

        private void Start()
        {
            DOTween.Sequence()
                .Append(ButtonWin.transform.DOScale(7f, 2f))
                .AppendInterval(0.7f)
                .Append(ButtonWin.transform.DOScale(2f, 2f))
                .SetLoops(-1);
        }
    }
}
