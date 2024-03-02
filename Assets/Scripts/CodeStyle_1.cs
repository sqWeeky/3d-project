using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlaces;

    private Transform[] _places;
    private int _numberOfPlace = 0;

    private void Start()
    {
        _places = new Transform[_allPlaces.childCount];

        for (int i = 0; i < _allPlaces.childCount; i++)
            _places[i] = _allPlaces.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform nextPoint = _places[_numberOfPlace];
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, _speed * Time.deltaTime);

        if (transform.position == nextPoint.position)
            GetNextPlace();
    }

    private Vector3 GetNextPlace()
    {
        _numberOfPlace++;

        if (_numberOfPlace == _places.Length)
            _numberOfPlace = 0;

        Vector3 pointPlace = _places[_numberOfPlace].transform.position;
        transform.forward = pointPlace - transform.position;
        return pointPlace;
    }
}