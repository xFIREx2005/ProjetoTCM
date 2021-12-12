using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player2Follow : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    public float distance;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        agent.speed = 7;
        agent.SetDestination(target.transform.position);
    }
}
