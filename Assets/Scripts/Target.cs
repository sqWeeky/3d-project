using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;
    private int _NextWaypoint = 1;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) < 0.2f)
        {
            if (_currentWaypoint == _waypoints.Count - 1)
            {
                _NextWaypoint = -1;
            }

            if (_currentWaypoint == 0)
            {
                _NextWaypoint = 1;
            }

            _currentWaypoint += _NextWaypoint;
        }
    }
}