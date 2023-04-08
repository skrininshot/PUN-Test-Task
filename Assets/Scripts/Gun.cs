using UnityEngine;
using System.Collections;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _shootInterval;
    [SerializeField] private float _long = 0.75f;
    private bool _canShoot = true;
    private BulletPool _bulletPool;

    private void Start()
    {
        _bulletPool = BulletPool.Singleton;
    }

    public void Shooting()
    {
        if (_canShoot)
            StartCoroutine(ShootTimer());
    }

    private void Shot()
    {
        Vector2 position = _transform.position + _transform.right * _long;
        _bulletPool.CreateBullet(position, _transform.rotation);
        _canShoot = false;
    }

    private IEnumerator ShootTimer()
    {
        Shot();

        yield return new WaitForSeconds(_shootInterval);

        _canShoot = true;
    }
}
