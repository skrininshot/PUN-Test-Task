using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Singleton;

    [SerializeField] private Transform _transform;
    [SerializeField] private int _bulletCount;
    [SerializeField] private Bullet _bulletPrefab;

    private List<Bullet> _bullets = new ();

    private void Awake()
    {
        if (Singleton)
        {
            Destroy(gameObject);

            return;
        }

        Singleton = this;
    }

    private void Start()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Bullet newBullet = Instantiate(_bulletPrefab, _transform);
            newBullet.gameObject.SetActive(false);
            _bullets.Add(newBullet);
        }
    }

    private Bullet GetAvailableBullet()
    {
        foreach (Bullet bullet in _bullets)
        {
            if (!bullet.gameObject.activeSelf)
                return bullet;
        }

        return null;
    }

    public void CreateBullet(Vector3 startPoint, Quaternion direction)
    {
        Bullet bullet = GetAvailableBullet();
        bullet.gameObject.SetActive(true);
        bullet.SetBullet(startPoint, direction);
    }
}
