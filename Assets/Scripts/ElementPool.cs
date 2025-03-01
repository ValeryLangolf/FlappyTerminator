using UnityEngine;

public abstract class ElementPool : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Collider2D _collider;    

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall _))
        {
            Deactivate();
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _mover.SetDirection(direction);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}