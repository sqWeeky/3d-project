using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoolBomb : MonoBehaviour
{
    [SerializeField] private Transform _containerObjects;
    [SerializeField] private Bomb _prefabBomb;
    [SerializeField] private TextMeshProUGUI _text;

    private Queue<Bomb> _poolBomb;
    private int _container;
    private int _activeBombs;

    public event Action ValueIncreased;
    public event Action ValueDecreased;

    private void Awake()
    {
        _poolBomb = new Queue<Bomb>();
    }

    public Bomb GetBomb(Transform transform)
    {
        if (_poolBomb.Count == 0)
        {
            var bomb = Instantiate(_prefabBomb);
            ValueIncreased?.Invoke();
            ShowQuantity();
            bomb.transform.parent = _containerObjects;
            bomb.gameObject.transform.position = transform.position;
            return bomb;
        }

        var bomb_1 = _poolBomb.Dequeue();
        ValueIncreased?.Invoke();
        ShowQuantity();
        bomb_1.gameObject.transform.position = transform.position;
        return bomb_1;
    }

    public void PutCube(Bomb bomb)
    {
        _poolBomb.Enqueue(bomb);
        ValueDecreased?.Invoke();
        bomb.gameObject.SetActive(false);
    }

    public int GetNumberActiveBomb()
    {
        _activeBombs = _container - _poolBomb.Count;
        return _activeBombs;
    }

    private void ShowQuantity()
    {
        _container++;
        _text.text = $"Всего создано бомб: {_container}";
    }
}