using UnityEngine;

public class HUDFollow : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    
    private Vector3 _offset; 

    private void Start()
    {
        if (_cameraTransform == null)
        {
            _cameraTransform = Camera.main.transform;
        }

        _offset = transform.position - _cameraTransform.position;
    }

    private void LateUpdate()
    {
        if (_cameraTransform != null)
        {
            transform.position = _cameraTransform.position + _offset;
        }
    }
}