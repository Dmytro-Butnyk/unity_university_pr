using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _offset;

    void Start()
    {
        _mainCamera = Camera.main;

        _offset = transform.position - _mainCamera.transform.position;
    }

    void LateUpdate()
    {
        if (_mainCamera != null)
        {
            transform.position = _mainCamera.transform.position + _offset;
        }
    }
}