using UnityEngine;

public class IPoolable : MonoBehaviour, IPool
{
    [SerializeField] private Bomb _prefab;
}
