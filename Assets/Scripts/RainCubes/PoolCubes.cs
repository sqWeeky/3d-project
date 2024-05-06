using System.Collections.Generic;
using UnityEngine;

public class PoolCubes : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Cube _prefabCube;

    private Queue<Cube> _poolCubes;

    private void Awake()
    {
        _poolCubes = new Queue<Cube>();
    }

    public Cube GetCube()
    {
        if (_poolCubes.Count == 0)
        {
            var cube = Instantiate(_prefabCube);
            cube.transform.parent = _container;
            cube.gameObject.SetActive(true);
            return cube;
        }

        var cube_1 = _poolCubes.Dequeue();
        cube_1.ConfigureDefaultSettings();
        return cube_1;
    }

    public void PutCube(Cube cube)
    {
        _poolCubes.Enqueue(cube);
        cube.gameObject.SetActive(false);
    }
}