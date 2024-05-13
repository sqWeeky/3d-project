using UnityEngine;

public class Ground : MonoBehaviour
{
    private float _positionX;
    private float _positionY = 0f;
    private float _positionZ;
    private Vector3 _positionUpperBound;
    private Vector3 _positionLowerBound;

    public Vector3 PositionUpperBound => _positionUpperBound;
    public Vector3 PositionLowerBound => _positionLowerBound;

    private void Awake()
    {
        FindUpperBound();
        FindLowerBound();
    }

    private void FindUpperBound()
    {
        _positionX = transform.position.x + transform.localScale.x / 2f;
        _positionZ = transform.position.z + transform.localScale.z / 2f;
        _positionUpperBound = new Vector3(_positionX, _positionY, _positionZ);
    }

    private void FindLowerBound()
    {
        _positionX = transform.position.x - transform.localScale.x / 2f;
        _positionZ = transform.position.z - transform.localScale.z / 2f;
        _positionLowerBound = new Vector3(_positionX, _positionY, _positionZ);
    }
}