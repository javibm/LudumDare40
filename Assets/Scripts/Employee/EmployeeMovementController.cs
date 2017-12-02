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

  void Test()
  {
    animController.WorkAnim();
  }

  public void MoveToProcrastinationTarget()
  {
    if (Target == personalOfficeDesk.Transform)
    {
      selectNewTarget();
    }
    navigate(Idle);
  }

  public void MoveToDesk()
  {
    if (Target != personalOfficeDesk.Transform)
    {
      Target = personalOfficeDesk.Transform;
    }
    navigate(Work);
  }

  public void Work()
  {
    animController.WorkAnim();
  }

  public void Idle()
  {
    animController.IdleAnim();
  }

  private void selectNewTarget()
  {
    Target = GameMetaManager.Office.DeskList[Random.Range(0, GameMetaManager.Office.DeskList.Count)].transform;
  }

  private void navigate(NavMeshController.OnNavigateFinished del)
  {
    navMeshController.NavigateTo(Target, Speed, del);
    animController.WalkAnim();
  }

  private OfficeDesk personalOfficeDesk;
  private NavMeshController navMeshController;
  private EmployeeAnimationController animController;

}
