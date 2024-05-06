using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube_1), typeof(Explosion))]
public class Divider : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private int _minValueCubes = 2;
    private int _maxValueCubes = 4;
    private int _valueCubes;
    private int _counter;

    private Cube_1 _cube;
    private Explosion _explosion;

    private void Awake()
    {
        _cube = GetComponent<Cube_1>();
        _explosion = GetComponent<Explosion>();
    }

    public void ActivateDivision(float defaultRadius, float defaultForce)
    {
        _valueCubes = CreatValue();
        List<Rigidbody> cubes = new();

        for (_counter = 0; _counter < _valueCubes; _counter++)
        {
            Cube_1 cube = _spawner.Activate(_cube);
            cube.ChangeCharacteristics(_cube.ChanceDivider, _cube.Radius, _cube.Force);

            if (cube.TryGetComponent(out Rigidbody component))
                cubes.Add(component);
        }

        _explosion.Activate(cubes, defaultRadius, defaultForce);
    }

    private int CreatValue()
         => Random.Range(_minValueCubes, _maxValueCubes + 1);
}