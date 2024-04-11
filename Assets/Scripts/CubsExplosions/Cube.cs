using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _chanceDivider;
    private float _maxValue = 100;
    private float _minValue = 0;
    private float _value;

    private Click _click;
    private Divider _divider;
    private Explosion _explosion;

    private void Awake()
    {
        _click = GetComponent<Click>();
        _divider = GetComponent<Divider>();
        _explosion = GetComponent<Explosion>();
    }
    private void Start()
    {
        _chanceDivider = _divider.CurrentChance;
    }

    private void OnEnable()
    {
        _click.ClickCompleted += IsSuccess;
    }

    private void OnDisable()
    {
        _click.ClickCompleted -= IsSuccess;
    }

    private void IsSuccess()
    {
        _value = Random.Range(_minValue, _maxValue);
        Debug.Log(_value);
        Debug.Log(_chanceDivider);

        if (_value <= _chanceDivider)
        {
            _divider.ActivateDivision();
        }
        else
        {
            _explosion.Activate();
        }
    }
}
