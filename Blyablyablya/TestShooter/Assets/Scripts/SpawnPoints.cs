using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public static SpawnPoints Instance;

    private List<Transform> spawnPoints = new List<Transform>();

    private void Awake()
    {
        Instance = this;

        foreach(Transform t in transform)
            spawnPoints.Add(t);
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)].position;
    }
}
