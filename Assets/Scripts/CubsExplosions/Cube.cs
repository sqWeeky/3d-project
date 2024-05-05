using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Divider), typeof(Explosion), typeof(Click))]
public class Cube : MonoBehaviour
{
    private float _chanceDivider = 100;
    private float _maxValue = 100;
    private float _minValue = 0;
    private float _value;
    private int _delta = 2;
    private float _defaultRadius = 5f;
    private float _radius = 10f;
    private float _defaultForce = 1000f;
    private float _force = 1000f;

    private MeshRenderer _renderer;
    private Click _click;
    private Divider _divider;
    private Explosion _explosion;
    private List<Rigidbody> _cubes = new();

    public float ChanceDivider => _chanceDivider;
    public float Radius => _radius;
    public float Force => _force;

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
        _click.ActionCompleted += DefineAction;
    }

    private void OnDisable()
    {
        _click.ActionCompleted -= DefineAction;
    }

    public void ChangeCharacteristics(float chanceDivider, float radius, float force)
    {
        ChangeScale();
        ChangeChanceDivider(chanceDivider);
        ChangeColor();
        ChangeRange(radius);
        ChangeForce(force);
    }

    private void ScanAreaInRange()
    {
        _cubes.Clear();

        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;

            if (rigidbody)
            {
                _cubes.Add(rigidbody);
            }
        }
    }

    private void ChangeRange(float radius) => _radius = radius * _delta;

    private void ChangeForce(float force) => _force = force * _delta;

    private void ChangeScale() => transform.localScale = transform.localScale / _delta;

    private void ChangeChanceDivider(float chanceDivider) => _chanceDivider = chanceDivider /= _delta;

    private void ChangeColor() => _renderer.material.color = CreateColor();

    private void DefineAction()
    {
        _value = UnityEngine.Random.Range(_minValue, _maxValue);

        if (_value <= _chanceDivider)
        {
            _divider.ActivateDivision(_defaultRadius, _defaultForce);
        }
        else
        {
            ScanAreaInRange();
            _explosion.Activate(_cubes, _radius, _force);
            Destroy(gameObject);
        }
    }

    private Color CreateColor() => UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
}