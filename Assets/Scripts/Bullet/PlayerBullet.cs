using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Deactivate();
            Deactivate();
        }
    }
}