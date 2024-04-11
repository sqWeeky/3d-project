using UnityEngine;

public class Divider : MonoBehaviour
{
    private int _minValueCubes = 2;
    private int _maxValueCubes = 4;
    private int _valueCubes;
    private int _counter;
    private float _delta = 2f;
    private float _alpha = 1f;
    private float _currentChance = 100;

    private MeshRenderer _renderer;

    public float CurrentChance => _currentChance;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _renderer.material.color = CreateColor();
    }

    public void ActivateDivision()
    {
        CountCubes();

        _counter = 0;

        while (_counter != _valueCubes)
        {
            Divider cube = Instantiate(this);
            cube.transform.localScale = transform.localScale / _delta;
            cube._currentChance /= _delta;
            cube._renderer.material.color = CreateColor();
            _counter++;
        }

        Destroy(gameObject);
    }

    private void CountCubes()
    {
        _valueCubes = Random.Range(_minValueCubes, _maxValueCubes + 1);
    }

    private Color CreateColor()
    {
        float r = UnityEngine.Random.Range(0, 1f);
        float g = UnityEngine.Random.Range(0, 1f);
        float b = UnityEngine.Random.Range(0, 1f);

        return new Color(r, g, b, _alpha);
    }
}