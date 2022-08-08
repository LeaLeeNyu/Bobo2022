using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpDescendConditionSO", menuName = "State Machine/Condition/JumpDescendCondition")]
public class JumpDescendConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return JumpDescend(controller);
    }

    private bool JumpDescend(StateController controller)
    {
        if(!controller.boboInput.jumpInput && controller.boboRB.velocity.y <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
