using UnityEngine;

public class GeneratorBomb : MonoBehaviour
{
    [SerializeField] private PoolBomb _poolBomb;

    public void Generate(Transform transform)
    {
        var bomb = _poolBomb.GetBomb(transform);
        bomb.Activate();
    }
}