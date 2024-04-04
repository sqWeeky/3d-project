using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _duration;

    private string _changeText = "Фигурки";
    private string _additionText = " двигаются";
    private string _hackText = " Текст перешифровался";

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText(_changeText, _duration));
        sequence.Append(_text.DOText(_additionText, _duration).SetRelative());
        sequence.Append(_text.DOText(_hackText, _duration, true, ScrambleMode.All));
    }
}
