using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoolCubes : MonoBehaviour
{
    [SerializeField] private Transform _containerObjects;
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private TextMeshProUGUI _text;

    private Queue<Cube> _poolCubes;
    private int _container;
    private int _activeCubes;

    public event Action ValueIncreased;
    public event Action ValueDecreased;

    private void Awake()
    {
        _poolCubes = new Queue<Cube>();
    }

    public Cube GetObject()
    {
        if (_poolCubes.Count == 0)
        {
            var cube = Instantiate(_prefabCube);
            ShowQuantity();
            ValueIncreased?.Invoke();
            cube.transform.parent = _containerObjects;
            return cube;
        }

        var cube_1 = _poolCubes.Dequeue();
        ValueIncreased?.Invoke();
        cube_1.ConfigureDefaultSettings();
        ShowQuantity();
        return cube_1;
    }

    public void PutCube(Cube cube)
    {
        _poolCubes.Enqueue(cube);
        ValueDecreased?.Invoke();
        cube.gameObject.SetActive(false);
    }

    public int GetNumberActiveCubes()
    {
        _activeCubes = _container - _poolCubes.Count;
        return _activeCubes;
    }

    private void ShowQuantity()
    {
        _container++;
        _text.text = $"Всего создано кубов: {_container}";
    }
}