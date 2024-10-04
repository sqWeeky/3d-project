using UnityEngine;

public class Root : MonoBehaviour
{
    public static Root Instance { get; private set; }

    public Pool<IPoolable> _pool;
    public GeneratorBombs GeneratorBombs;
    public GeneratorCubes GeneratorCubes;
    public PoolC PoolCubes;

    private void Awake()
    {
        Instance = this;
        _pool = new Pool<IPoolable>();
    }

    private void Start()
    {
    }
}