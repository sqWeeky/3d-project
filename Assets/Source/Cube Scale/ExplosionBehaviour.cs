using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _explosionForce = 500f;

    private void Awake()
    {
        _explosionRadius *= transform.localScale.x;
        _explosionForce *= transform.localScale.x;
    }

    public void Explode(Vector3 origin)
    {
        Collider[] colliders = Physics.OverlapSphere(origin, _explosionRadius);

        foreach (var collider in colliders)
        {
            if (collider.attachedRigidbody != null)
                collider.attachedRigidbody.AddExplosionForce(_explosionForce, origin, _explosionRadius);
        }
    }
}
