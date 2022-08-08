using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RestartConditionSO", menuName = "State Machine/Condition/RestartCondition")]
public class RestartConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return controller.aniController.restartAniEnd;
    }
}
