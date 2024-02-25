using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _destroyTime = 15;
    private Vector3 _worldMousePosition;

    private void Start()
    {
        CreatPosition();
        Invoke("DestroyBullet", _destroyTime);
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void CreatPosition()
    {
        _worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _worldMousePosition.y = 0f;
    }

    private void Move()
    {
        transform.Translate(_worldMousePosition.normalized * _speed * Time.deltaTime);
    }
}