using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensitive : MonoBehaviour
{
    private bool _onStairs = false;

    public bool OnStairs => _onStairs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            _onStairs = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            _onStairs = false;
        }
    }
}
