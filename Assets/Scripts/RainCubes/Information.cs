using TMPro;
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberOfCubes;
    [SerializeField] private TextMeshProUGUI _numberOfBombs;

    private int _containerCubes = 0;
    private int _containerBombs = 0;

    //private void OnEnable()
    //{
    //    Root.Instance.GeneratorCubes.CubeIncreased += IncreaseValueCubes;
    //    Root.Instance.GeneratorBombs.BombIncreased += IncreaseValueBombs;
    //}

    //private void OnDisable()
    //{
    //    Root.Instance.GeneratorCubes.CubeIncreased -= IncreaseValueCubes;
    //    Root.Instance.GeneratorBombs.BombIncreased -= IncreaseValueBombs;
    //}

    private void Update()
    {
        ShowInfo();
    }

    private void IncreaseValueCubes()
    {
        _containerCubes++;
    }

    private void IncreaseValueBombs()
    {
        _containerBombs++;
    }

    private void DecreaseValueCubes()
    {
        _containerCubes--;
    }

    private void DecreaseValueBombs()
    {
        _containerBombs--;
    }

    private void ShowInfo()
    {
        //_numberOfCubes.text = $"�������� ����� �� �����: {_containerCubes}";
        //_numberOfBombs.text = $"�������� ���� �� �����: {_containerBombs}";
    }

    private void ShowQuantity()
    {
        //_number++;
        //_text.text = $"����� ������� ����: {_number}";
    }

}
