using UnityEngine;

public class Shooter : MonoBehaviour
{
    private BulletPool _bulletPool;

    public void InitBulletPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void Shoot()
    {
        Bullet bullet = _bulletPool.Get();
        bullet.transform.position = transform.position;
        bullet.SetDirection(transform.up);
        bullet.gameObject.SetActive(true);
    }
}