using System;
using System.Collections;
using UnityEngine;

public class Enemy : ElementPool, IDeactivatable<Enemy>
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _delayBetweenShots;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private bool _isShooting;

    public event Action<Enemy> Deactivated;

    private void Awake()
    {
        _wait = new(_delayBetweenShots);
    }

    public void InitBulletPool(EnemyBulletPool bulletPool)
    {
        _shooter.InitBulletPool(bulletPool);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Deactivated?.Invoke(this);
    }

    private void OnEnable()
    {
        _isShooting = true;
        _coroutine = StartCoroutine(ShootContinuously());
    }

    private void OnDisable()
    {
        _isShooting = false;
        StopCoroutine(_coroutine);
    }

    private IEnumerator ShootContinuously()
    {
        while (_isShooting)
        {
            yield return _wait;

            _shooter.Shoot();
        }
    }
}