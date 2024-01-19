using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] float spawnTime;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        spawnTime = Random.Range(1, 3);
        Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
    }
}
