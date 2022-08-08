using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpDescendToIdleSO", menuName = "State Machine/Condition/JumpDescendToIdle")]
public class JumpDescendToIdleSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return Mathf.Abs(controller.boboRB.velocity.y) < 0.1f;
    }
}
