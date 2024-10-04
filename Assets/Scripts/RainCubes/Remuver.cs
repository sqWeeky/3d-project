using System;
using UnityEngine;

public class Remuver : IPoolable
{
    [SerializeField] private PoolC _poolCubes;
    [SerializeField] private PoolB _poolBomb;
    //[SerializeField] private Cube _prefabCube;
    //[SerializeField] private Bomb _prefabBomb;

    public event Action CubeDecreased;
    public event Action BombDecreased;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Cube cube))
        {
            _poolCubes.GetObject(cube);
            //Root.Instance._pool.PutObgect(cube as IPoolable);
            CubeDecreased?.Invoke();
        }
        else if(collider.TryGetComponent(out Bomb bomb))
        {
            _poolBomb.GetObject(bomb);
            //Root.Instance._pool.PutObgect(bomb as IPoolable);
            BombDecreased?.Invoke();
        }
    }
}