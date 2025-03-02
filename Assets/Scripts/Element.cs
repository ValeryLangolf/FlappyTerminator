using UnityEngine;

public abstract class Element : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Collider2D _collider;    

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall _))
            Deactivate();
    }

    public abstract void Deactivate();

    public void SetPosition(Vector2 position) =>
        transform.position = position;

    public void SetDirection(Vector3 direction) =>
        _mover.SetDirection(direction);
}