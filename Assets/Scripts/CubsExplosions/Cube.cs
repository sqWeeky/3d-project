using UnityEngine;
using System;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Divider), typeof(Explosion), typeof(Click))]
public class Cube : MonoBehaviour
{
    private float _chanceDivider = 100;
    private float _maxValue = 100;
    private float _minValue = 0;
    private float _value;
    private float _delta = 2f;

    private MeshRenderer _renderer;
    private Click _click;
    private Divider _divider;
    private Explosion _explosion;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _click = GetComponent<Click>();
        _divider = GetComponent<Divider>();
        _explosion = GetComponent<Explosion>();
    }

    private void Start()
    {
        ChangeColor();
    }

    private void OnEnable()
    {
        _click.ClickCompleted += DefineAction;
    }

    private void OnDisable()
    {
        _click.ClickCompleted -= DefineAction;
    }

    public void ChangeCharacteristics()
    {
        ChangeScale();
        _chanceDivider = ChangeChanceDivider();
        ChangeColor();
    }

    private void ChangeScale() => transform.localScale = transform.localScale / _delta;

    private float ChangeChanceDivider() => _chanceDivider /= _delta;

    private void ChangeColor() => _renderer.material.color = CreateColor();

    private void DefineAction()
    {
        _value = UnityEngine.Random.Range(_minValue, _maxValue);

        if (_value <= _chanceDivider)
        {
            _divider.ActivateDivision();
        }
        else
        {
            _explosion.Activate();
        }
    }

    private Color CreateColor() => UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
}