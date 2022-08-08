using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiedConditionSO", menuName = "State Machine/Condition/DiedCondition")]
public class DiedConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return controller.wither.died;
    }


}
