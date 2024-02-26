using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Poolable
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Health _enemyHealth;

    private void Start()
    {
        if(!_agent)
            _agent = GetComponent<NavMeshAgent>();

        SearchForTarget();

        _enemyHealth.onDeath += FreeEnemy;
    }

    public void SearchForTarget()
    {
        _agent.enabled = false;
        _agent.enabled = true;
        _agent.isStopped = false;

        _agent.SetDestination(Player.Instance.transform.position);
    }

    private void FreeEnemy()
    {
        ObjectPool.Instance.ReturnEnemyToPool(this);
    }

    public override void OnGet()
    {
        _agent.enabled = true;
        //SearchForTarget();
    }

    public override void OnReturn()
    {
        _agent.isStopped = true;
        _agent.enabled = false;
    }
}
