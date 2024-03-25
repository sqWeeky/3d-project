using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private float _time = 0.5f;
    private float _counter = 0;
    private float _currentTime = 0;
    private bool _isActive = false;

    private void Start()
    {
        StartCoroutine(Count());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isActive = !_isActive;

            StartCoroutine(Count());
        }
    }

    private IEnumerator Count()
    {
        while (_isActive == true)
        { 
            if (_currentTime > _time)
            {
                _currentTime = 0;
                _counter++;
                _text.text = _counter.ToString();
            }
            else
            {
                _currentTime += Time.deltaTime;
            }

            yield return null;
        }
    }
}