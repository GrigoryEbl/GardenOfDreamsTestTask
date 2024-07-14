using UnityEngine;

public class PlayerMover :  AbstarctMover
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 direction)
    {
        if (direction != null)
        {
            _rigidbody2D.velocity = (direction * _speed * Time.deltaTime).normalized;
            
            if (_rigidbody2D.velocity.x < 0)
            {
                Flip(false);
            }
            else if (_rigidbody2D.velocity.x > 0)
            {
                Flip(true);
            }
        }
    }

    public void Stop()
    {
        if (_rigidbody2D != null)
        {
            _rigidbody2D.velocity = Vector3.zero;
        }
    }
}