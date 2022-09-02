using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrueConditionSO", menuName = "State Machine/Condition/TrueCondition")]
public class TrueConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return true;
    }
}
