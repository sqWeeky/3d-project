using DG.Tweening;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private Material _spriteRenderer;
    [SerializeField] private Color _color;
    [SerializeField] private float _duration;

    private void Start()
    {
        _spriteRenderer.DOColor(_color, _duration).SetEase(Ease.Linear);
    }
}