using System;

public abstract class Bullet : Element, IDeactivatable<Bullet>
{
    public event Action<Bullet> Deactivated;

    public override void Deactivate() =>
        Deactivated?.Invoke(this);
}