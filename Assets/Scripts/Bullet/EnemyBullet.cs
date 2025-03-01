using UnityEngine;

public class EnemyBullet : Bullet 
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.gameObject.SetActive(false);
            Deactivate();
        }
    }
}