using UnityEngine;

public class Root : MonoBehaviour
{
    public static Root Instance { get; private set; }

    public GeneratorBomb GeneratorBomb;
    public PoolCubes PoolCubes;

    private void Awake()
    {
        Instance = this;
    }
}