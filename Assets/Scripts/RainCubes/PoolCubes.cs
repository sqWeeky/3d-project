using System.Collections.Generic;
using UnityEngine;

public class PoolCubes : MonoBehaviour
{
    [SerializeField] private Transform _containerObjects;
    [SerializeField] private Cube _prefabCube;

    private Queue<Cube> _pool;

    private void Awake()
    {
        _pool = new Queue<Cube>();
    }

    public Cube GetObject()
    {
        if (_pool.Count == 0)
        {
            var cube = Instantiate(_prefabCube);
            cube.transform.parent = _containerObjects;
            return cube;
        }

        var cube_1 = _pool.Dequeue();
        cube_1.ConfigureDefaultSettings();
        return cube_1;
    }

    public void PutCube(Cube cube)
    {
        _pool.Enqueue(cube);
        cube.gameObject.SetActive(false);
    }
}