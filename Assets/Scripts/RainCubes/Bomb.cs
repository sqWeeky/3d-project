using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explotionRadius;
    [SerializeField] private float _explotionForse;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private float _delay;

    private float _maxAlpha = 1f;
    private float _minAlpha = 0f;
    private float _delta = 10f;
    private Color _color;
    private SphereCollider _collider;
    private Coroutine _coroutine;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _renderer.material = new Material(_renderer.material);
    }

    private void Start()
    {
        SetDefaultCharacteristics();
    }

    public void Activate()
    {
        SetDefaultCharacteristics();
        gameObject.SetActive(true);
        _coroutine = StartCoroutine(StartDetonation());
    }

    private IEnumerator ChangeAlphaColor()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while (Mathf.Approximately(_renderer.material.color.a, _minAlpha) == false)
        {
            Color color = _renderer.material.color;
            color.a = Mathf.MoveTowards(color.a, _minAlpha, _delta * Time.deltaTime);
            _renderer.material.color = color;
            yield return waitForSeconds;
        }        

        if (Mathf.Approximately(_renderer.material.color.a, _minAlpha) == false)
        {
            yield break;
        }
    }

    private IEnumerator StartDetonation()
    {
        yield return ChangeAlphaColor();

        Explode();
        ChangeTrigger();

        StopCoroutine(_coroutine);
    }

    private void ChangeTrigger() => _collider.isTrigger = true;

    private void SetDefaultCharacteristics()
    {
        _color.a = _maxAlpha;
        _renderer.material.color = _color;
        _collider.isTrigger = false;
    }    

    private void Explode()
    {
        foreach (Rigidbody obj in GetExplodebleObgect())
            obj.AddExplosionForce(_explotionForse, transform.position, _explotionRadius);        
    }

    private List<Rigidbody> GetExplodebleObgect()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explotionRadius);
        List<Rigidbody> _obj = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null && (hit.gameObject.TryGetComponent(out Cube _) || hit.gameObject.TryGetComponent(out Bomb _)))
                _obj.Add(hit.attachedRigidbody);

        return _obj;
    }
}