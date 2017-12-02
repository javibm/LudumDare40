using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeMovementController : MonoBehaviour {

  public Transform Target
  {
    get;
    private set;
  }

  public float Speed
  {
    get;
    set;
  }

  public void Init(OfficeDesk officeDesk, NavMeshController navMeshController)
  {
    personalOfficeDesk = officeDesk;
    personalOfficeDesk.Taken = true;

    this.navMeshController = navMeshController;

    Speed = 1;
  }

  public void MoveToProcrastinationTarget()
  {
    if (Target == personalOfficeDesk.Transform)
    {
      selectNewTarget();
    }
    navigate();
  }

  public void MoveToDesk()
  {
    if (Target != personalOfficeDesk.Transform)
    {
      Target = personalOfficeDesk.Transform;
    }
    navigate();
  }

  private void selectNewTarget()
  {
  }

  private void navigate()
  {
    navMeshController.NavigateTo(Target, Speed);
  }

  private OfficeDesk personalOfficeDesk;
  private NavMeshController navMeshController;

}
