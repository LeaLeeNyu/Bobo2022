using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FinishLevelConditionSO", menuName = "State Machine/Condition/FinishLevelCondition")]
public class FinishLevelConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return controller.scoreManager.gameEnd;
    }
}
