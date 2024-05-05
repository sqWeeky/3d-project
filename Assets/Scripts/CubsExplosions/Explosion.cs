using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Activate(List<Rigidbody> list, float radius, float force)
    {
        Explode(list, radius, force);
        Destroy(gameObject);
    }

    private void Explode(List<Rigidbody> list, float radius, float force)
    {
        foreach (Rigidbody explodableObject in list)
            explodableObject.AddExplosionForce(force, transform.position, radius);
    }
}