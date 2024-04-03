using DG.Tweening;
using UnityEngine;

public class MoverCube : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _durationPosition;
    [SerializeField] private float _durationRotation;
    [SerializeField] private float _durationScale;
    [SerializeField] private int _repeats;

    private void Start()
    {
        transform.DOMove(_position, _durationPosition).SetLoops(_repeats, LoopType.Yoyo).SetEase(Ease.Linear);
        transform.DORotate(_rotation, _durationRotation).SetLoops(_repeats,LoopType.Restart).SetEase(Ease.Linear);
        transform.DOScale(_scale, _durationScale).SetLoops(_repeats, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}