using UnityEngine;

public class PlayerTosser : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Toss()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }
}