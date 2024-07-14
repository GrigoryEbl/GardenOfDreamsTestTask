using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private int _positionZ;
    [SerializeField] private int _positionY;

    private Vector3 _target;

    private void Update()
    {
        _target = _player.position;
        _target.z = _positionZ;
        _target.y += _positionY;
        transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * _speed);
    }
}
