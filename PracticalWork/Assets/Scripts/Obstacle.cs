using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _damage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage(_damage);
        }
    }
}