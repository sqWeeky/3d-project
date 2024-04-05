using DG.Tweening;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private Material _spriteRenderer;
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_spriteRenderer.DOColor(_color1, _duration).SetEase(Ease.Linear));
        sequence.Append(_spriteRenderer.DOColor(_color2, _duration).SetEase(Ease.Linear));
        sequence.SetLoops(_repeats, LoopType.Yoyo);
    }
}