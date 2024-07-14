using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnRadius;

    private int _spawnCount = 3;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        Spawn();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            Vector2 RandomPosition = Random.insideUnitCircle * _spawnRadius;
            Instantiate(_enemyPrefab, RandomPosition, Quaternion.identity, _transform);
        }
    }
}
