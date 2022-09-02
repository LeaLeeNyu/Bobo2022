using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StealthQuitConditionSO", menuName = "State Machine/Condition/StealthQuitCondition")]
public class StealthQuitConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return controller.boboInput.stealthQuitInput;
    }
}
