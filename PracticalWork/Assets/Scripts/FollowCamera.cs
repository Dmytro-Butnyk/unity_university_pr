using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectAssets.Scripts
{
    public sealed class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothSpeed = 0.125f;
        [SerializeField] private Vector3 _offset;
        
        [Header("Bounds")]
        [SerializeField] private Vector2 _minPosition;
        [SerializeField] private Vector2 _maxPosition;

        private void Awake()
        {
            Assert.IsNotNull(_target, "Target is required");
        }

        private void LateUpdate()
        {
            Vector3 targetPosition = _target.position + _offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, _smoothSpeed);

            float clampX = Mathf.Clamp(smoothedPosition.x, _minPosition.x, _maxPosition.x);
            float clampY = Mathf.Clamp(smoothedPosition.y, _minPosition.y, _maxPosition.y);

            transform.position = new Vector3(clampX, clampY, smoothedPosition.z);
        }
    }
}