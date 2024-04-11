using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerClickHandler
{
    private int _pointerId = -1;
    private int _maxChance = 100;
    private int _minChance = 0;
    private int _currentChance = 50;
    private int _divider = 2;
    private int _value;
    private float _alpha = 1f;
    private MeshRenderer _renderer;

    public event Action ClickCompleted;
    public event Action BangCompleted;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();        
    }

    private void Start()
    {
        _renderer.material.color = CreateColor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == _pointerId)
        {
            if (IsSuccess() == true)
            {
                Debug.LogError("Δελενθε");
                ClickCompleted?.Invoke();
            }
            else
            {
                Debug.LogError("Bang");
                BangCompleted?.Invoke();
            }
        }
    }

    private bool IsSuccess()
    {
        _value = UnityEngine.Random.Range(_minChance, _maxChance);
        Debug.Log(_value);
        Debug.Log(_currentChance);

        if (_value < _currentChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Color CreateColor()
    {
        float r = UnityEngine.Random.Range(0, 1f);
        float g = UnityEngine.Random.Range(0, 1f);
        float b = UnityEngine.Random.Range(0, 1f);       

        return new Color(r, g, b, _alpha);
    }
}