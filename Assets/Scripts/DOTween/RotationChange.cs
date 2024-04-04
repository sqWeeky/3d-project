using DG.Tweening;
using UnityEngine;

public class RotationChange : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;

    private void Start()
    {
        transform.DORotate(_rotation, _duration).SetLoops(_repeats, LoopType.Restart).SetEase(Ease.Linear);
    }
}