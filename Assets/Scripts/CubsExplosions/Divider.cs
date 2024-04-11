using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divider : MonoBehaviour
{
    private int _minValueCubes = 2;
    private int _maxValueCubes = 4;
    private int _valueCubes;
    private int _counter;
    private int _divider = 2;

    private Click _click;
    private Transform _transform;

    private void Awake()
    {
        _click = GetComponent<Click>();
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _click.ClickCompleted += ActivateDivision;
    }

    private void OnDisable()
    {
        _click.ClickCompleted -= ActivateDivision;
    }

    private void ActivateDivision()
    {
        CountCubes();

        _counter = 0;

        while (_counter != _valueCubes)
        {
            var cube = Instantiate(_transform);
            cube.localScale = transform.localScale / _divider;
            _counter++;
        }

        Destroy(gameObject);
    }

    private void CountCubes()
    {
        _valueCubes = Random.Range(_minValueCubes, _maxValueCubes + 1);
    }
}