using UnityEngine;

public class PlayerMover :  AbstarctMover
{
    [SerializeField] protected float _speed;

    private Transform _transform;
    protected Rigidbody2D _rigidbody2D;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    public override void Move(Vector2 direction)
    {
        if (direction != null)
        {
            if (name == "Enemy")
                print(direction);

            //_rigidbody2D.MovePosition(_rigidbody2D.position + direction * _speed * Time.fixedDeltaTime);
            _rigidbody2D.velocity = (direction * _speed * Time.deltaTime).normalized;
            Flip();
            //_transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.Self);
            //_transform.position = Vector2.MoveTowards(_transform.position, direction.normalized ,_speed* Time.deltaTime);
            IsMoving = true;
        }
    }

    public void Stop()
    {
        if (_rigidbody2D != null)
        {
            _rigidbody2D.velocity = Vector3.zero;
            print(name + "Stoped");
        }

        IsMoving = false;
    }

    private void Flip()
    {
        if (_rigidbody2D.velocity.x < 0)
        {
            _transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (_rigidbody2D.velocity.x > 0)
        {
            _transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}