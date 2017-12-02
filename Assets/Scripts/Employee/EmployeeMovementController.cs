using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeMovementController : MonoBehaviour {

  public Transform Target
  {
    get
    {
      return target;
    }
  }

  public float Speed
  {
    get;
    set;
  }

  public void MoveToProcrastinationTarget(Transform target)
  {
    // TODO RANDOM PROCRASTINATION TARGET
  }

  public void MoveToDesk()
  {

  }

  private Transform target;

}
