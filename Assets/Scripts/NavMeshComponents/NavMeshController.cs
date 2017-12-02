using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class NavMeshController : MonoBehaviour
{

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.autoBraking = true;
  }

  void Update()
  {
    if ((!agent.pathPending && agent.remainingDistance < 0.01f) || agent.isStopped )
    {
      agent.isStopped = true;
    }
  }

  public void NavigateTo(Transform target, float speed)
  {
    agent.isStopped = false;
    agent.speed = speed;
    agent.destination = target.position;
  }

  private NavMeshAgent agent;
}