using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiedToRestartConditionSO", menuName = "State Machine/Condition/DiedToRestartCondition")]
public class DiedToRestartConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return controller.aniController.diedAniEnd;
    }
}
