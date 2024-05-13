using UnityEngine;

public class Remuver : MonoBehaviour
{
    [SerializeField] private PoolCubes _poolCubes;
    [SerializeField] private PoolBomb _poolBomb;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Cube cube))
        {
            _poolCubes.PutCube(cube);
        }
        else if(collider.TryGetComponent(out Bomb bomb))
        {
            _poolBomb.PutCube(bomb);
        }
    }
}