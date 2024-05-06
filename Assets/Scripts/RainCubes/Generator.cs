using System.Collections;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private PoolCubes _pool;

    private float _upperBound = 25f;
    private float _lowerBound = -25f;
    private int _positionY = 15;

    private void Start()
    {
        StartCoroutine(GenerateObject());
    }

    private IEnumerator GenerateObject()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionX = Random.Range(_upperBound, _lowerBound);
        float spawnPositionZ = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(spawnPositionX, _positionY, spawnPositionZ);

        var newObject = _pool.GetCube();
        newObject.gameObject.SetActive(true);
        newObject.transform.position = spawnPoint;
    }
}