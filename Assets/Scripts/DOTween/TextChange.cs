using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _duration;

    private string _changeText = "�������";
    private string _additionText = " ���������";
    private string _hackText = " ����� ��������������";

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText(_changeText, _duration));
        sequence.Append(_text.DOText(_additionText, _duration).SetRelative());
        sequence.Append(_text.DOText(_hackText, _duration, true, ScrambleMode.All));
    }
}
