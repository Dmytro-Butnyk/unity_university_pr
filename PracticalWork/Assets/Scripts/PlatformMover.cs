using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float distance = 3f;
    public float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newX = startPos.x + Mathf.Sin(Time.time * speed) * distance;
        
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }
}