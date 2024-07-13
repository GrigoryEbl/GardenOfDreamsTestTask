using UnityEngine;

public abstract class AbstarctMover: MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] private Transform _body;

    public virtual void Move() { }
    public virtual void Move(Vector2 vector) { }

    public virtual void Flip() { }

    public virtual void Flip(bool isRight)
    {
        if (isRight == false)
        {
            _body.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (isRight)
        {
            _body.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

