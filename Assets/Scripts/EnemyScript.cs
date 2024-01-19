using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        player = PlayerScript.Instance.playerObject;
    }
    void Update()
    {
        if (FindDistanceToPlayer().magnitude <= 0)
        {
            PlayerScript.Instance.playerHealth -= 1;
            Destroy(gameObject);
        }
    }

    Vector3 FindDistanceToPlayer()
    {
        return player.transform.position - this.transform.position;
    }
}
