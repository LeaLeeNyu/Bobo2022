using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpConditionSO", menuName = "State Machine/Condition/JumpCondition")]
public class OnJumpConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return controller.boboInput.jumpInput;
    }





}
