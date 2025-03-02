using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerRotator _rotator;
    [SerializeField] private Jumper _tosser;
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private PlayerBullet _playerBulletPrefab;

    private readonly Shooter _shooter = new();
    private Pool<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new Pool<Bullet>(_playerBulletPrefab);
        _shooter.SetBulletPool(_bulletPool);
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
        _tosser.Jump();
        _rotator.RotateUp();
    }

    private void OnShotButtonPressed() =>
        _shooter.Shoot(transform);
}