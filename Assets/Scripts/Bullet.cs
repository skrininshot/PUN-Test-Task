using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonTransformView))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField, Min(1f)] private float _speed = 20f;
    [SerializeField] private float _damage = 20f;

    public void SetBullet(Vector3 startPoint, Quaternion direction)
    {
        _transform.position = startPoint;
        _transform.rotation = direction;
        _rigidbody.velocity = _transform.right * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerController player))
        {
            player.GetDamage(_damage);
            Disable();
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
