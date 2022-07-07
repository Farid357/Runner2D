using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public sealed class PlayerMovement : MonoBehaviour
{
    public static Vector3 Position => _transform.position;
    private static Transform _transform;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _force = 150;

    private Vector2 _direction = Vector2.right;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private static float _sSpeed;
    public bool IsGrounded { get; private set; }

    private void Start()
    {
        _sSpeed = _speed;
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() => Move(_direction);

    private void Move(Vector2 direction)
    {
        _speed = _sSpeed;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _animator.SetBool("EndJump", true);
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            IsGrounded = false;
        }
    }
    public static void IncreaseSpeed()
    {
        if (_sSpeed < 3.9f)
            _sSpeed += 0.1f;
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _force * 100 * _speed, ForceMode2D.Force);
            _animator.SetTrigger("IsJumping");
            _animator.SetBool("EndJump", false);
        }
    }
}
