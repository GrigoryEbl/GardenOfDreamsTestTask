using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private Transform _transform;
    private Rigidbody2D _rigidbody2D;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * _speed;

        Flip();

        IsMoving = true;
    }

    public void Stop()
    {
        if (_rigidbody2D != null)
            _rigidbody2D.velocity = Vector3.zero;

        IsMoving = false;
    }

    private void Flip()
    {
        if (_rigidbody2D.velocity.x < 0)
        {
            _transform.rotation = Quaternion.Euler(0,180, 0);
        }
        else if (_rigidbody2D.velocity.x > 0)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}