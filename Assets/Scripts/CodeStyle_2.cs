using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _bullet;
    [SerializeField] private float _shotTime;
    [SerializeField] private Transform _target;

    private bool isWork;
    private Rigidbody _rigidbodyBullet;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        isWork = true;
        var waitForSeconds = new WaitForSeconds(_shotTime);

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Transform newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            _rigidbodyBullet = newBullet.GetComponent<Rigidbody>();
            _rigidbodyBullet.transform.up = direction;
            _rigidbodyBullet.velocity = direction * _speed;
            yield return waitForSeconds;
        }
    }
}