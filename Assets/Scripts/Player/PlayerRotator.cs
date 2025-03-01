using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minimumRotationZ;
    [SerializeField] private float _maximumRotationZ;

    private Quaternion _minimumRotation;
    private Quaternion _maximumRotation;

    private void Start()
    {
        _minimumRotation = Quaternion.Euler(0, 0, _minimumRotationZ);
        _maximumRotation = Quaternion.Euler(0, 0, _maximumRotationZ);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minimumRotation, _speed * Time.deltaTime);
    }

    public void RotateUp()
    {
        transform.rotation = _maximumRotation;
    }
}