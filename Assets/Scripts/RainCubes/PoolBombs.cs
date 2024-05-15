using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoolBombs : MonoBehaviour
{
    [SerializeField] private Transform _containerObjects;
    [SerializeField] private Bomb _prefabBomb;
    [SerializeField] private TextMeshProUGUI _text;

    private Queue<Bomb> _pool;

    private void Awake()
    {
        _pool = new Queue<Bomb>();
    }

    public Bomb GetBomb(Transform transform)
    {
        if (_pool.Count == 0)
        {
            var bomb = Instantiate(_prefabBomb);
            bomb.transform.parent = _containerObjects;
            bomb.gameObject.transform.position = transform.position;
            return bomb;
        }

        var bomb_1 = _pool.Dequeue();
        bomb_1.gameObject.transform.position = transform.position;
        return bomb_1;
    }

    public void PutBomb(Bomb bomb)
    {
        _pool.Enqueue(bomb);
        bomb.gameObject.SetActive(false);
    }
}