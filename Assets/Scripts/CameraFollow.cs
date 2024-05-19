using UnityEngine;

namespace TT
{
    public sealed class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void Update()
        {
            transform.position = _target.position;
            transform.rotation = _target.rotation;
        }
    }
}
