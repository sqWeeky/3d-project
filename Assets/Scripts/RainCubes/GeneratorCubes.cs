using System;
using System.Collections;
using UnityEngine;

public class GeneratorCubes : MonoBehaviour
{
    [SerializeField] private PoolC _pool;
    [SerializeField] private float _delay;
    [SerializeField] private Ground _ground;
    [SerializeField] private Transform _generator;
    [SerializeField] private Cube _prefab;

    private float _positionY;

    public event Action CubeIncreased;

    private void Awake()
    {
        _positionY = _generator.position.y;
    }

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
        float spawnPositionX = UnityEngine.Random.Range(_ground.PositionLowerBound.x, _ground.PositionUpperBound.x);
        float spawnPositionZ = UnityEngine.Random.Range(_ground.PositionLowerBound.z, _ground.PositionUpperBound.z);
        Vector3 spawnPoint = new Vector3(spawnPositionX, _positionY, spawnPositionZ);

        var newObject = _pool.GetObject(_prefab);
        //var newObject = (Cube)Root.Instance._pool.GetObject(_prefab);
        CubeIncreased?.Invoke();
        newObject.gameObject.SetActive(true);
        newObject.transform.position = spawnPoint;
    }
}