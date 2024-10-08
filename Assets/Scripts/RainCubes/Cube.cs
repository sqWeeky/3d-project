using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    private int _lifetime;
    private int _minLifetime = 2;
    private int _maxLifetime = 5;
    private float _period = 1f;
    private bool _isTouch = false;
    private Color _defaultColor = Color.blue;

    private MeshRenderer _renderer;
    private BoxCollider _boxCollider;
    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _renderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _renderer.material.color = _defaultColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            if (_isTouch == false)
            {
                _isTouch = true;
                _renderer.material.color = CreateColor();
                GeneratLifeTime();
                StartCoroutine(DieObject());
            }
        }
    }

    public void ConfigureDefaultSettings()
    {
        ChangeTrigger();
        ChangeColor();
        ChangeState();
    }

    private void ChangeTrigger() => _boxCollider.isTrigger = false;

    private void ChangeColor() => _renderer.material.color = _defaultColor;

    private void ChangeState() => _isTouch = false;

    private IEnumerator DieObject()
    {
        var waitForSeconds = new WaitForSeconds(_period);

        while (_lifetime > 0)
        {
            _lifetime--;

            if (_lifetime <= 0)
            {
                _boxCollider.isTrigger = true;
                Root.Instance.GeneratorBombs.Generate(_cube.transform);
                yield break;
            }

            yield return waitForSeconds;
        }
    }

    private void GeneratLifeTime()
    {
        _lifetime = UnityEngine.Random.Range(_minLifetime, _maxLifetime + 1);
    }

    private Color CreateColor() => UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
}