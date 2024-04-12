using System;
using UnityEngine;

public class EntityClonerClient : MonoBehaviour
{
    private const KeyCode CloneKey = KeyCode.Mouse0;
    [SerializeField, Range(1, 10)] private int _minClonesCount;
    [SerializeField, Range(1, 10)] private int _maxClonesCount;

    private EntityModifyBehaviour _entityModifyBehaviour;
    private ExplosionBehaviour _explosionBehaviour;
    private DisappearBehaviour _disappearBehaviour;

    private void OnValidate()
    {
        if (_minClonesCount >= _maxClonesCount)
            _maxClonesCount = _minClonesCount + 1;
    }

    private void Awake()
    {
        _entityModifyBehaviour = GetComponent<EntityModifyBehaviour>();
        _explosionBehaviour = GetComponent<ExplosionBehaviour>();
        _disappearBehaviour = GetComponent<DisappearBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(CloneKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Entity entity))
                {
                    if (UnityEngine.Random.Range(0, 100) < entity.CloneChance)
                        Clone(entity);
                    else
                        Disappear(entity);
                }
            }
        }
    }

    private void Clone(ICloneableEntity cloneable)
    {
        int randomClonesCount = UnityEngine.Random.Range(_minClonesCount, _maxClonesCount);

        for (int i = 0; i < randomClonesCount; i++)
        {
            Entity clone = cloneable.Clone();
            _entityModifyBehaviour.Modify(clone);
        }

        _explosionBehaviour.Explode(cloneable.Transform.position);
        Destroy(cloneable.Transform.gameObject);
    }

    private void Disappear(Entity entity)
    {
        StartCoroutine(_disappearBehaviour.DisappearAsync(entity));
    }
}
