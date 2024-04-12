using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void Activate(List<Rigidbody> list)
    {
        Explode(list);
        Destroy(gameObject);
    }

    private void Explode(List<Rigidbody> list)
    {
        foreach (Rigidbody explodableObject in list)
            explodableObject.AddExplosionForce(_force, transform.position, _radius);
    }
}