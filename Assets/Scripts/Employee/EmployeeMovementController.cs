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

  public void Init(OfficeDesk officeDesk, NavMeshController navMeshController, EmployeeAnimationController animController)
  {
    personalOfficeDesk = officeDesk;
    personalOfficeDesk.Taken = true;

    this.navMeshController = navMeshController;
    this.animController = animController;

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
    Target = GameMetaManager.Office.DeskList[Random.Range(0, GameMetaManager.Office.DeskList.Count)].transform;
  }

  private void navigate()
  {
    navMeshController.NavigateTo(Target, Speed);
    animController.WalkAnim();
  }

  private OfficeDesk personalOfficeDesk;
  private NavMeshController navMeshController;
  private EmployeeAnimationController animController;

}
