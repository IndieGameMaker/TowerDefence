using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _playerTr;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerTr = GameObject.FindGameObjectWithTag("Player").transform;

        _agent.speed = 1.5f;
        _agent.SetDestination(_playerTr.position);
        _agent.isStopped = false;
    }

    private int _hp = 100;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
