using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _enemy;
    //[SerializeField] private int _maxEnemies;
    //[SerializeField] private float _timeSpawn;

   // private int _spawnCount = 0;
   // private float _timer;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(_enemy, transform);
        newEnemy.SetTarget(_target);
        //if (_spawnCount < _maxEnemies)
        //{
        //    Enemy newEnemy = Instantiate(_enemy, transform);
        //    newEnemy.SetTarget(_target);
        //    _spawnCount++;
        //    yield return new WaitForSeconds(_timeSpawn);
        //    StartCoroutine(SpawnEnemys());
        //}
        //else
        //{
        //    yield return null;
        //}
    }
}