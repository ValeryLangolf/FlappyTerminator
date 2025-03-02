using System;
using System.Collections;
using UnityEngine;

public class Enemy : Element, IDeactivatable<Enemy>
{
    [SerializeField] private float _delayBetweenShots;

    private readonly Shooter _shooter = new();
    private WaitForSeconds _wait;
    private bool _isShooting;

    public event Action<Enemy> Deactivated;

    private void Awake() =>
        _wait = new(_delayBetweenShots);

    public void InitBulletPool(Pool<Bullet> pool) =>
        _shooter.SetBulletPool(pool);

    public override void Deactivate() =>
        Deactivated?.Invoke(this);

    private void OnEnable()
    {
        _isShooting = true;
        StartCoroutine(ShootContinuously());
    }

    private IEnumerator ShootContinuously()
    {
        while (_isShooting)
        {
            yield return _wait;

            _shooter.Shoot(transform);
        }
    }
}