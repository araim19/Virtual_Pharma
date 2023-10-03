using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAvatar : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 destination;
    void Start()
    {
        agent.SetDestination(destination);
    }

}
