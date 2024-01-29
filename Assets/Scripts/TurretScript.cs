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
    }

    void RotateTurret()
    {
        if (targetEnemy == null) return;

        Vector3 directionToEnemy = targetEnemy.position - transform.position;

        if (directionToEnemy.magnitude > 0.1f)
        {
            directionToEnemy.z = 0;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToEnemy.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turretTurnRate);
        }
    }

    void FindAndTargetEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        targetEnemy = null;

        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            var distanceToEnemy = enemy.transform.position - transform.position;

            if (distanceToEnemy.magnitude <= turretRange)
            {
                if (targetEnemy == null || distanceToEnemy.magnitude < closestDistance)
                {
                    targetEnemy = enemy.transform;
                    closestDistance = distanceToEnemy.magnitude;
                }
            }
        }

        CheckAndShoot();
    }

    void CheckAndShoot()
    {
        if (targetEnemy == null) return;

        RotateTurret();

        var distanceToEnemy = targetEnemy.position - transform.position;
        if (FindDotProduct(distanceToEnemy) >= 0.99f && timeToFire <= 0f)
        {
            ShootLaser();
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

    float FindDotProduct(Vector3 distance)
    {
        return transform.up.x * distance.normalized.x
            + transform.up.y * distance.normalized.y
            + transform.up.z * distance.normalized.z;
    }
}
