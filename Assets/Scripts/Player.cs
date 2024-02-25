using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _startTime;

    private int _health = 5;
    private float _timeShot;

    void Update()
    {        
        Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _health--;
            Debug.Log("Отнятие 1 ед жизни");

            if ( _health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Вы умерли");
            }
        }
    }

    private void Shoot()
    {
        if (_timeShot <= 0)
        { 
            if (Input.GetMouseButton(0))
            {
                Bullet bullet = Instantiate<Bullet>(_bullet, transform.position, Quaternion.identity);
                _timeShot = _startTime;
            }
        }
        else
        {
            _timeShot -= Time.deltaTime;
        }
    }
}