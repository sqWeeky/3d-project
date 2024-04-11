using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private AudioSource _clip;

    private Click _click;

    private void Awake()
    {
        _click = GetComponent<Click>();
    }

    private void OnEnable()
    {
        _click.BangCompleted += Activate;
    }

    private void OnDisable()
    {
        _click.BangCompleted -= Activate;
    }

    private void Activate()
    {
        Explode();
        Debug.Log(_clip.clip);
        _clip.Play();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_force, transform.position, _radius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}