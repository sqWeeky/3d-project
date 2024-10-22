using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Follower : MonoBehaviour
{
    [SerializeField] private MoveCharacter _target;
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _stepHeight = 15f;
    [SerializeField] private Sensitive _sensitive;

    private Rigidbody _rigidbody;
    private Vector3 _move;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Follow();
        StepStairs();
    }

    private void Follow()
    {
        if (_target != null)
        {
            _move = _target.transform.localPosition - transform.localPosition;
            _rigidbody.AddForce(_move * _speed * Time.deltaTime, ForceMode.Force);
        }
    }

    private void StepStairs()
    {
        if (_sensitive.OnStairs == true)
        {
            _rigidbody.AddForce(Vector3.up * _stepHeight );
        }
    }
}