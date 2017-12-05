using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavMeshController : MonoBehaviour
{

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.updateRotation = false;
  }

  void Update()
  {
    if (target != null)
    {
      Quaternion newRotation = Quaternion.LookRotation(target.position - transform.position);
      newRotation.x = 0f;
      newRotation.z = 0f;
      transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10f);
    }

    if ((!agent.pathPending && agent.remainingDistance < 0.1f && target != null) || agent.isStopped)
    {
      agent.isStopped = true;
      transform.rotation = target.rotation;
      transform.position = target.position;

      if (NavigateFinishedCallback != null)
      {
        NavigateFinishedCallback();
      }
    }
  }

  public void NavigateTo(Transform target, float speed, OnNavigateFinished del)
  {
    this.target = target;
    if(agent != null)
    {
      agent.destination = target.position;
      agent.speed = speed;
      agent.isStopped = false;
    }
    NavigateFinishedCallback = del;
  }

  private Transform target;
  private NavMeshAgent agent;
  public delegate void OnNavigateFinished();
  public OnNavigateFinished NavigateFinishedCallback;

}