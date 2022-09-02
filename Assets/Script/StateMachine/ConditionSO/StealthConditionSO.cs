using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StealthConditionSO", menuName = "State Machine/Condition/StealthCondition")]
public class StealthConditionSO : Condition
{
    private bool collideGround;
    public override bool stateCondition(StateController controller)
    {
        collideGround = controller.wither.collideGround;

        // if bobo on the ground and player press the stealth button
        return controller.boboInput.stealthInput && controller.wither.collideGround;
    }
}
