using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform target)
       => _target = target;

    private void Move()
        => transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
}