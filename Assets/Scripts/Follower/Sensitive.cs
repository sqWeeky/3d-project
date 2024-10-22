using UnityEngine;

public class Sensitive : MonoBehaviour
{
    private int _numberLayerMaskStairs = 7;
    private bool _onStairs = false;

    public bool OnStairs => _onStairs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _numberLayerMaskStairs)
        {
            _onStairs = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _numberLayerMaskStairs)
        {
            _onStairs = false;
        }
    }
}
