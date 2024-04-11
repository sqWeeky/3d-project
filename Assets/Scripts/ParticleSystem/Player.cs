using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _glitter;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _position;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Jump");
            Instantiate(_glitter, _position);
        }
    }
}