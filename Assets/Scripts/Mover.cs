using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * _direction;
    }
}