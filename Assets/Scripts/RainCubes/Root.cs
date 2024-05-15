using UnityEngine;

public class Root : MonoBehaviour
{
    public static Root Instance { get; private set; }

    public ObjectPool<IPoolable> _pool;
    public GeneratorBombs GeneratorBombs;
    public GeneratorCubes GeneratorCubes;
    //public PoolCubes PoolCubes;

    private void Awake()
    {
        Instance = this;
        //_pool = new ObjectPool<IPoolable>();
    }

    private void Start()
    {
    }
}