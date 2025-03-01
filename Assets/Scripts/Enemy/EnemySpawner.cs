using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private EnemyBulletPool _bulletPool;
    [SerializeField] private SpawnPoint _spawnPointUp;
    [SerializeField] private SpawnPoint _spawnPointDown;
    [SerializeField] private float _delayInSeconds;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;
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
    }

    private void OnEnable()
    {
        _isSpawn = true;
        _coroutine = StartCoroutine(SpawnOverTime());
    }

    private void OnDisable()
    {
        _isSpawn = false;
        StopCoroutine(_coroutine);
    }

    private IEnumerator SpawnOverTime()
    {
        while (_isSpawn)
        {
            yield return _wait;

            Enemy enemy = _enemyPool.Get();

            float positionY = Random.Range(_minimumPositionY, _maximumPositionY);
            enemy.transform.position = new Vector2(_positionX, positionY);

            enemy.InitBulletPool(_bulletPool);
            enemy.SetDirection(_direction);
            enemy.gameObject.SetActive(true);
        }
    }
}