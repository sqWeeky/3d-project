using UnityEngine;

public class MoveEnem : MonoBehaviour
{
    [SerializeField] private float _speed;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}