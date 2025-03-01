using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerRotator _rotator;
    [SerializeField] private PlayerTosser _tosser;
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private PlayerBulletPool _bulletPool;
    [SerializeField] private Shooter _shooter;

    private void Awake()
    {
        _shooter.InitBulletPool(_bulletPool);
    }

    private void OnEnable()
    {
        _inputSystem.JumpButtonPressed += OnJumpButtonPressed;
        _inputSystem.ShotButtonPressed += OnShotButtonPressed;
    }

    private void OnDisable()
    {
        _inputSystem.JumpButtonPressed -= OnJumpButtonPressed;
        _inputSystem.ShotButtonPressed -= OnShotButtonPressed;
    }

    private void OnJumpButtonPressed()
    {
        _tosser.Toss();
        _rotator.RotateUp();
    }

    private void OnShotButtonPressed()
    {
        _shooter.Shoot();
    }
}