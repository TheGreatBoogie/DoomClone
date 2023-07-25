using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform _playerPosition;
    private EnemyAwarness _enemyAwarness;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _enemyAwarness = GetComponent<EnemyAwarness>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerPosition = FindObjectOfType<PlayerMove>().transform;

        if (_enemyAwarness.isAware)
        {
            agent.SetDestination(_playerPosition.position);
        }
    }
}
