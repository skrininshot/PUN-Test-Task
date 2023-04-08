using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField, Min(0)] private float _moveSpeed = 5f;
    [SerializeField, Range(0.1f, 1f)] private float _shootingDeadZone = 0.9f;
    [SerializeField] private PlayerCamera _cameraPrefab;

    private Joystick _moveJoystick;
    private Joystick _rotateJoystick;
    private Vector2 _moveDirection;
    private Vector2 _rotateDirection;

    private void Start()
    {
        _moveJoystick = GameUI.Singleton.LeftJoystick;
        _rotateJoystick = GameUI.Singleton.RightJoystick;

        if (_photonView.IsMine)
            Instantiate(_cameraPrefab, Vector3.zero, Quaternion.identity).SetHost(_transform);
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
        _moveDirection = _moveJoystick.Direction.normalized;
        _rotateDirection = _rotateJoystick.Direction.normalized;
    }

    private void Move()
    {
        _rigidbody.velocity = _moveSpeed * _moveDirection;
    }

    private void RotateAndShoot()
    {
        if (_rotateDirection.magnitude < 0.1f) return;

        float angle = Mathf.Atan2(_rotateDirection.y, _rotateDirection.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
