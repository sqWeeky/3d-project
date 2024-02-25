using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            _health--;

            if ( _health <= 0)
                Destroy(gameObject);

            Destroy(other);
        }
    }
}
