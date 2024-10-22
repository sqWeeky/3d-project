using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jump = 10f;

    private float _forseJump;
    private Vector3 _move;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (_characterController.isGrounded != true)        
            _forseJump += _gravity * Time.deltaTime;        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        _move = new Vector3(x * _speed, _forseJump, z * _speed) * Time.deltaTime;
        _characterController.Move(_move);
    }

    private void Jump()
    {
        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _forseJump = _jump;
        }
    }
}
