using UnityEngine;

public class RemuverCubes : MonoBehaviour
{
    [SerializeField] private PoolCubes _poolCubes;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Cube cube))
        {
            _poolCubes.PutCube(cube);
        }
    }
}