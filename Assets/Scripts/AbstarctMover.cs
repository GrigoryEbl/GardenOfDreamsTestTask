using UnityEngine;

public abstract class AbstarctMover: MonoBehaviour
{
    [SerializeField] protected float _speed;
    public virtual void Move() { }
    public virtual void Move(Vector2 vector) { }
}

