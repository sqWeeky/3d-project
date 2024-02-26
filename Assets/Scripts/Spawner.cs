using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _maxEnemies;
    [SerializeField] private int _timeSpawn;

    private int _spawnCount = 0;
    //private int _minValue = -15;
    //private int _maxValue = 15;

    private void Start()
    {
        StartCoroutine(SpawnEnemys());
    }

    private IEnumerator SpawnEnemys()
    {
        if (_spawnCount < _maxEnemies)
        {
            Enemy newEnemy = Instantiate(_enemy, transform);
            //_direction = new Vector3(Random.Range(_minValue, _maxValue), 0f, Random.Range(_minValue, _maxValue)).normalized;
            newEnemy.SetDirection(_target.transform.position.normalized);
            _spawnCount++;
            yield return new WaitForSeconds(_timeSpawn);
            StartCoroutine(SpawnEnemys());
        }
        else
        {
            yield return null;
        }
    }
}