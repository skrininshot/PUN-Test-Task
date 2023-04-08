using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonTransformView))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField, Min(0)] private float _moveSpeed = 5f;
    [SerializeField, Range(0.1f, 1f)] private float _shootingDeadZone = 0.9f;
    [SerializeField] private PlayerCamera _cameraPrefab;
    [SerializeField] private Gun _gun;

    private PlayerCamera _camera;
    private float hp = 100;
    private Joystick _moveJoystick;
    private Joystick _rotateJoystick;
    private Vector2 _moveDirection;
    private Vector2 _rotateDirection;

    private void Start()
    {
        _moveJoystick = GameUI.Singleton.LeftJoystick;
        _rotateJoystick = GameUI.Singleton.RightJoystick;

        if (_photonView.IsMine)
        {
            _camera = Instantiate(_cameraPrefab, Vector3.zero, Quaternion.identity);
            _camera.SetHost(_transform);
        }
        else
            Destroy(_rigidbody);
    }

    private void Update()
    {
        if (_photonView.IsMine)
            ProcessInputs();
    }

    private void FixedUpdate()
    {
        if (!_photonView.IsMine) return;

        Move();
        RotateAndShoot();
    }

    private void ProcessInputs()
    {
        _moveDirection = _moveJoystick.Direction;
        _rotateDirection = _rotateJoystick.Direction;
    }

    private void Move()
    {
        _rigidbody.velocity = _moveSpeed * _moveDirection;
    }

    private void RotateAndShoot()
    {
        if (_rotateDirection.sqrMagnitude < 0.1f) return;

        float angle = Mathf.Atan2(_rotateDirection.y, _rotateDirection.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (_rotateDirection.magnitude > _shootingDeadZone)
            _gun.Shooting();
    }

    public void GetDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
            Dead();
    }

    private void Dead()
    {
        gameObject.SetActive(false);
        _camera.enabled = false;
    }
}
