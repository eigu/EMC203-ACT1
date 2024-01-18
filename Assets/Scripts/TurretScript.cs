using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private float _turretRange;
    [SerializeField] private float _turretFireRate;
    [SerializeField] private float _turretTurnRate;

    void Update()
    {
        if (FindDistanceToObject().magnitude <= _turretRange && FindDotProduct(FindDistanceToObject()) >= .99f)
            ShootBullet();
    }

    private Vector3 FindDistanceToObject()
    {
        return PlayerScript._playerObject.gameObject.transform.position - _bulletSpawn.position;
    }

    private float FindDotProduct(Vector3 _range)
    {
        return _bulletSpawn.up.x * _range.normalized.x + _bulletSpawn.up.y * _range.normalized.y;
    }

    void ShootBullet()
    {
        Destroy(PlayerScript._playerObject);
    }
}