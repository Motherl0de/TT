using System;
using DG.Tweening;
using UnityEngine;

namespace TT
{
    public sealed class AnimMenu : MonoBehaviour
    {
        private float _duration = 1f;

        private void Start()
        {
            DOTween.Sequence()
                .Append(transform.DOScale( 1.75f, _duration))
                .AppendInterval(0.5f)
                .Append(transform.DOScale(3,_duration))
                .SetLoops(-1);
        }
    }
}
