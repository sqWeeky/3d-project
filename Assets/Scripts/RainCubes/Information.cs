using TMPro;
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] private PoolBomb _poolBombs;
    [SerializeField] private PoolCubes _poolCubes;
    [SerializeField] private TextMeshProUGUI _text;

    private int _container;

    private void OnEnable()
    {
        _poolBombs.ValueIncreased += IncreaseValue;
        _poolBombs.ValueDecreased += DecreaseValue;
        _poolCubes.ValueIncreased += IncreaseValue;
        _poolCubes.ValueDecreased += DecreaseValue;
    }

    private void OnDisable()
    {
        _poolBombs.ValueIncreased -= IncreaseValue;
        _poolBombs.ValueDecreased -= DecreaseValue;
        _poolCubes.ValueIncreased -= IncreaseValue;
        _poolCubes.ValueDecreased -= DecreaseValue;
    }

    private void Update()
    {
        ShowInfo();
    }

    private void IncreaseValue()
    {
        _container++;
    }

    private void DecreaseValue()
    {
        _container--;
    }

    private void ShowInfo()
    {
        _text.text = $"Активных объектов на сцене: {_container}";
    }
}
