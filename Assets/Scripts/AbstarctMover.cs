using UnityEngine;

public abstract class AbstarctMover: MonoBehaviour
{
    private float _speed;
    public virtual void Move() { }
    public virtual void Move(Vector2 vector) { }
}

