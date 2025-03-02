using UnityEngine;

public class Shooter
{
    private Pool<Bullet> _bulletPool;

    public void SetBulletPool(Pool<Bullet> pool) =>
        _bulletPool = pool;

    public void Shoot(Transform transform)
    {
        Bullet bullet = _bulletPool.Get();
        bullet.SetPosition(transform.position);
        bullet.SetDirection(transform.up);
    }
}