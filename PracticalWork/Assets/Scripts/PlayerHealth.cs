using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _currentHealth;
    
    private HealthView _healthView;
    private RestartView _restartView;
    
    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;

    [Inject]
    public void Construct(HealthView healthView, RestartView restartView)
    {
        _healthView = healthView;
        _restartView = restartView;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        
        _healthView.UpdateHealthDisplay(_currentHealth);
        
        if (_restartView != null)
        {
            var btn = _restartView.GetRestartButton();
            if (btn != null) btn.onClick.AddListener(RestartGame);
        }
        
        Time.timeScale = 1f;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"HP: {_currentHealth}");

        transform.position = _startPosition;
        if (_rigidbody != null) _rigidbody.linearVelocity = Vector2.zero;

        _healthView.UpdateHealthDisplay(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_restartView != null) 
            _restartView.Show();
            
        Time.timeScale = 0f; 
        Debug.Log("Game Over");
    }

    private void RestartGame()
    {
        _currentHealth = _maxHealth;
        _healthView.UpdateHealthDisplay(_currentHealth);

        transform.position = _startPosition;
        if (_rigidbody != null) _rigidbody.linearVelocity = Vector2.zero;

        if (_restartView != null) 
            _restartView.Hide(); 
            
        Time.timeScale = 1f;
        Debug.Log("Restarted!");
    }
    
    private void OnDestroy()
    {
        if (_restartView != null)
        {
             var btn = _restartView.GetRestartButton();
             if (btn != null) btn.onClick.RemoveListener(RestartGame);
        }
    }
}