using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StealthMovingConditionSO", menuName = "State Machine/Condition/StealthMovingCondition")]
public class StealthMovingConditionSO : Condition
{
    public float threshold = 0.1f;

    public override bool stateCondition(StateController controller)
    {
        Vector2 moveInput = controller.boboInput.stealthMoveVectorInput;
        return moveInput.magnitude > threshold;
    }
}
