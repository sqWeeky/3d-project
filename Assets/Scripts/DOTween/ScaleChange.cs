using DG.Tweening;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;

    private void Start()
    {
        transform.DOScale(_scale, _duration).SetLoops(_repeats, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}