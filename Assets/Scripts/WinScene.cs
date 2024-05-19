
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TT
{
    public sealed class WinScene : MonoBehaviour
    {
        private Button _buttonWin;
        private Button ButtonWin => _buttonWin ??= GetComponent<Button>();
        private void Update()
        {
            //ButtonWin.transform.DOScale();
        }
    }
}
