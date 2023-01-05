using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConditionSO", menuName = "State Machine/Condition/MapCondition")]
public class MapConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return controller.cameraLook.lookMap;
    }
}


