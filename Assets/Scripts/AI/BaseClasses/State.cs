using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/State")]
public class State : ScriptableObject 
{

    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(EmployeeStateController controller)
    {
        DoActions (controller);
        CheckTransitions (controller);
    }

    private void DoActions(EmployeeStateController controller)
    {
        for (int i = 0; i < actions.Length; i++) {
            actions [i].Act (controller);
        }
    }

    private void CheckTransitions(EmployeeStateController controller)
    {
        for (int i = 0; i < transitions.Length; i++) 
        {
            bool decisionSucceeded = transitions [i].decision.Decide (controller);

            if (decisionSucceeded) {
                controller.UpdateState (transitions [i].trueState);
            } else 
            {
                if (transitions [i].falseState != null)
                {
                    controller.UpdateState (transitions [i].falseState);
                }
            }
        }
    }


}