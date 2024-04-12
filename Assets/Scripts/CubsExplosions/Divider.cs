using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Divider : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private int _minValueCubes = 2;
    private int _maxValueCubes = 4;
    private int _valueCubes;
    private int _counter;

    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    public void ActivateDivision()
    {
        _valueCubes = CreatRandomValue();

        for (_counter = 0; _counter < _valueCubes; _counter++)
        {
            Cube cube = _spawner.Activate(_cube);
            cube.ChangeCharacteristics();
        }

        Destroy(gameObject);
    }

    private int CreatRandomValue()
         => Random.Range(_minValueCubes, _maxValueCubes + 1);   
}