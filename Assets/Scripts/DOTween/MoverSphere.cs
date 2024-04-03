using UnityEngine;
using DG.Tweening;

public class MoverSphere : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;

    private void Start()
    {
        transform.DOMove(_position, _duration).SetLoops(_repeats, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}