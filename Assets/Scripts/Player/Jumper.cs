using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody2D>();

    public void Jump()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }
}