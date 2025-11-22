using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectAssets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ObjectMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 20f;

        private Rigidbody2D _rigidbody;
        private Transform _originalParent;

        private float _horizontalInput = 0;
        private bool _isGrounded;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Assert.IsNotNull(_rigidbody, "Rigidbody2D is required");

            _originalParent = transform.parent;
        }

        private void Update()
        {
            // get horizontal direction 1 - move right; -1 - move left
            _horizontalInput = Input.GetAxis("Horizontal");
            
            // В Unity 6 используется linearVelocity, в старых - velocity.
            // Если тут будет ошибка, используй: _rigidbody.velocity = new Vector2(_horizontalInput * _speed, _rigidbody.velocity.y);
            _rigidbody.linearVelocity = new Vector2(_horizontalInput * _speed, _rigidbody.linearVelocity.y);
            
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _isGrounded = false;
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("MovingPlatform")) 
            {
                _isGrounded = true;
            }

            if (other.gameObject.GetComponent<PlatformMover>() != null)
            {
                transform.SetParent(other.transform);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlatformMover>() != null)
            {
                transform.SetParent(_originalParent);
            }
        }
    }
}