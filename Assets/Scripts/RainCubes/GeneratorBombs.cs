using System;
using UnityEngine;

public class GeneratorBombs : MonoBehaviour
{
    [SerializeField] private PoolBombs _pool;
    //[SerializeField] private IPoolable _prefab;

    public event Action BombIncreased;

    public void Generate(Transform transform)
    {
        var bomb = _pool.GetBomb(transform);
        //var bomb = (Bomb)Root.Instance._pool.GetObject(_prefab);
        BombIncreased?.Invoke();
        bomb.Activate();
    }
}