using System.Collections;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float turretRange;
    [SerializeField] private float turretFireRate;
    [SerializeField] private float turretTurnRate;

    private Transform targetEnemy;
    private float timeToFire;

    void Start()
    {
        timeToFire = turretFireRate;
    }

    void Update()
    {
        timeToFire -= Time.deltaTime;

        FindAndTargetEnemy();
        CheckForEnemy();
    }

    void RotateTurret()
    {
        Vector3 directionToEnemy = targetEnemy.position - transform.position;

        if (directionToEnemy.magnitude > 0.1f)
        {
            directionToEnemy.z = 0;
            transform.up = MovementLibrary.Slerp(transform.up, directionToEnemy.normalized, turretTurnRate * Time.deltaTime);
        }
    }

    void CheckForEnemy()
    {
        if (targetEnemy == null)
        {
            return;
        }

        var distanceToEnemy = FindDistance(transform.position, targetEnemy.position);

        if (distanceToEnemy.magnitude > turretRange)
        {
            targetEnemy = null;
        }

        if (distanceToEnemy.magnitude <= turretRange
            && FindDotProduct(distanceToEnemy) >= 0.999f
            && timeToFire <= 0f)
        {
            ShootLaser();
        }
    }

    void FindAndTargetEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            var distanceToEnemy = FindDistance(transform.position, enemy.transform.position);

            if (distanceToEnemy.magnitude <= turretRange)
            {
                targetEnemy = enemy.transform;
                RotateTurret();
                break;
            }
        }

    }

    void ShootLaser()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.SetPosition(0, bulletSpawn.position);
        lineRenderer.SetPosition(1, targetEnemy.position);

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        Destroy(targetEnemy.gameObject);
        timeToFire = turretFireRate;

        StartCoroutine(ShootingCooldown(lineRenderer));
    }

    IEnumerator ShootingCooldown(LineRenderer lineRenderer)
    {
        yield return new WaitForSeconds(1 / turretFireRate);

        Destroy(lineRenderer);
    }

    Vector3 FindDistance(Vector3 startPoint, Vector3 endPoint)
    {
        return endPoint - startPoint;
    }

    float FindDotProduct(Vector3 distance)
    {
        return transform.up.x * distance.normalized.x
            + transform.up.y * distance.normalized.y
            + transform.up.z * distance.normalized.z;
    }
}
