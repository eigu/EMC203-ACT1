using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform bulletSpawn;
    public float turretRange;

    void Update()
    {
        Vector3 toPlayer = PlayerScript.player.gameObject.transform.position - bulletSpawn.position;
        float dot = bulletSpawn.up.x * toPlayer.normalized.x + bulletSpawn.up.y * toPlayer.normalized.y;

        if (toPlayer.magnitude <= turretRange && dot >= .99f)
        {
            Destroy(PlayerScript.player);
        }
    }

    private void OnDrawGizmos()
    {   
        Gizmos.color = Color.green;
        Gizmos.DrawLine(bulletSpawn.position, bulletSpawn.position + bulletSpawn.up * (turretRange -.5f));
    }
}