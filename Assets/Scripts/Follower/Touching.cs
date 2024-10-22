using UnityEngine;

public class Touching : MonoBehaviour
{
    private int _numberLayerMaskStairs = 7;
    private bool _isStairs = false;

    public bool IsStairs => _isStairs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _numberLayerMaskStairs)
        {
            _isStairs = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _numberLayerMaskStairs)
        {
            _isStairs = false;
        }
    }
}
