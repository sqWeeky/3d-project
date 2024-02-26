using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 0.7f);
    }

    public void SpawnEnemy()
    {
        var enemy = ObjectPool.Instance.GetEnemyFromPool();
        enemy.transform.parent = null;
        enemy.transform.position = SpawnPoints.Instance.GetSpawnPoint();
        enemy.GetComponent<Enemy>().SearchForTarget();
    }
}
