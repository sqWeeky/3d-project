using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class Catapult : MonoBehaviour
{
    [SerializeField] private Vector3 _shotPosition;
    [SerializeField] private Vector3 _reloadPosition;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPointProjectile;
    [SerializeField] private float _delay = 10f;

    private SpringJoint _joint;
    private float _timer;

    private void Awake()
    {
        _joint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Reloding();
        }
    }

    private void Reloding()
    {
        _joint.connectedAnchor = _reloadPosition;
        SpawnProjectile();
    }

    private void Fire()
    {
        _joint.connectedAnchor = _shotPosition;
    }

    private void SpawnProjectile()
    {
        _timer = _delay;

        while (_timer > 0)
        {
            _timer--;

            if (_timer <= 0)
            {
                var obj = Instantiate(_prefab, _spawnPointProjectile);
                obj.transform.position = _spawnPointProjectile.position;
                break;
            }
        }
    }
}
