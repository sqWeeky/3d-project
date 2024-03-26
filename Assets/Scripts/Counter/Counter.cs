using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private float _period = 0.5f;
    private float _counter = 0;
    private bool _isActive = false;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isActive = !_isActive;

            if (_isActive)            
                _coroutine = StartCoroutine(Count());            
            else            
                StopCounter();            
        }
    }

    private void StopCounter()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Count()
    {
        var waitForSeconds = new WaitForSeconds(_period);

        while (true)
        {
            _counter++;
            _text.text = _counter.ToString();
            yield return waitForSeconds;
        }
    }
}