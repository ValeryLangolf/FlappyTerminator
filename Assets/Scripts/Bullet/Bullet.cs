using System;

public abstract class Bullet : ElementPool, IDeactivatable<Bullet>
{
    public event Action<Bullet> Deactivated;

    public override void Deactivate()
    {
        base.Deactivate();
        Deactivated?.Invoke(this);
    }
}