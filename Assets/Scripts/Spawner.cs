using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _maxEnemiesOnScreen;

    private float _spawnTimer = 2f;
    private int _spawnCount = 0;

    private void Update()
    {
        StartCoroutine(SpawnEnemys());
    }

    private IEnumerator SpawnEnemys()
    {
        if (_spawnCount <= _maxEnemiesOnScreen)
        {
            GameObject newEnemy = Instantiate(_enemy);
            newEnemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;
            _spawnCount++;
            yield return new WaitForSeconds(_spawnTimer);
        }
        else
        {
            yield return null;
        }
    }
}