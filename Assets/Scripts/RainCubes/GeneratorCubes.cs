using System.Collections;
using UnityEngine;

public class GeneratorCubes : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private PoolCubes _pool;
    [SerializeField] private Ground _ground;

    private readonly int _positionY = 15;

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            SpawnCubes();
            yield return wait;
        }
    }

    private void SpawnCubes()
    {
        float spawnPositionX = Random.Range(_ground.PositionLowerBound.x, _ground.PositionUpperBound.x);
        float spawnPositionZ = Random.Range(_ground.PositionLowerBound.z, _ground.PositionUpperBound.z);
        Vector3 spawnPoint = new Vector3(spawnPositionX, _positionY, spawnPositionZ);

        var newObject = _pool.GetObject();
        newObject.gameObject.SetActive(true);
        newObject.transform.position = spawnPoint;
    }
}