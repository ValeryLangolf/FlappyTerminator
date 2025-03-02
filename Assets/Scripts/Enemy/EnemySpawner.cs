using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private EnemyBullet _enemyBulletPrefab;
    [SerializeField] private SpawnPoint _spawnPointUp;
    [SerializeField] private SpawnPoint _spawnPointDown;
    [SerializeField] private float _delayInSeconds;

    private Pool<Enemy> _enemyPool;
    private Pool<Bullet> _enemyBulletPool;
    private WaitForSeconds _wait;
    private Vector2 _direction = Vector2.left;
    private bool _isSpawn;

    private float _positionX;
    private float _minimumPositionY;
    private float _maximumPositionY;

    private void Awake()
    {
        _wait = new(_delayInSeconds);

        _positionX = _spawnPointUp.transform.position.x;
        _minimumPositionY = _spawnPointDown.transform.position.y;
        _maximumPositionY = _spawnPointUp.transform.position.y;

        _enemyBulletPool = new Pool<Bullet>(_enemyBulletPrefab);

        _enemyPool = new Pool<Enemy>(
            prefab: _enemyPrefab,
            initializeCallback: enemy => enemy.InitBulletPool(_enemyBulletPool));
    }

    private void OnEnable()
    {
        _isSpawn = true;
        StartCoroutine(SpawnOverTime());
    }

    private void Spawn()
    {
        Enemy enemy = _enemyPool.Get();

        float positionY = Random.Range(_minimumPositionY, _maximumPositionY);
        Vector2 position = new(_positionX, positionY);

        enemy.SetPosition(position);
        enemy.SetDirection(_direction);
    }

    private IEnumerator SpawnOverTime()
    {
        while (_isSpawn)
        {
            yield return _wait;

            Spawn();
        }
    }
}