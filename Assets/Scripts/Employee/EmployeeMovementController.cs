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
    personalOfficeDesk.Filled = true;

    this.navMeshController = navMeshController;
    this.animController = animController;

    Speed = 1;
  }

  public void MoveToProcrastinationTarget()
  {
    if (Target == personalOfficeDesk.Transform)
    {
      selectNewTarget();
      navigate(GoToRandom);
    }
  }

  public void GoToRandom()
  {
    selectNewTarget();
    navigate(GoToRandom);
  }

  public void MoveToDesk()
  {
    if (Target != personalOfficeDesk.Transform)
    {
      Target = personalOfficeDesk.Transform;
      navigate(Work);
    }
  }

  public void GoToDestroy()
  {
    if (Target != personalOfficeDesk.Transform)
    {
      Target = personalOfficeDesk.Transform;
      navigate(DestroyAnim);
    }
  }

  public void Work()
  {
    animController.WorkAnim();
  }

  public void Idle()
  {
    animController.IdleAnim();
  }

  public void DestroyAnim()
  {
    animController.DestroyAnim();
  }

  private void selectNewTarget()
  {
    Target = GameMetaManager.Office.GetRandomIdle().transform;
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
