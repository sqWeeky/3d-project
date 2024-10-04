using System;
using UnityEngine;

public class GeneratorBombs : MonoBehaviour
{
    [SerializeField] private Pool<Bomb> _pool;
    //[SerializeField] private Bomb _prefab;

    public event Action BombIncreased;

    public void Generate(Transform prefab)
    {
        var bomb = _pool.GetObject();
        //var bomb = (Bomb)Root.Instance._pool.GetObject(prefab);
        BombIncreased?.Invoke();
        bomb.Activate();
    }
}