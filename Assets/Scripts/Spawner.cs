using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(_enemy, transform);
        newEnemy.SetTarget(_target);       
    }
}