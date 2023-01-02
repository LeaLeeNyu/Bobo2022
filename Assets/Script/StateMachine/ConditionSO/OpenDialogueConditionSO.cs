using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OpenDialogueConditionSO", menuName = "State Machine/Condition/OpenDialogueCondition")]
public class OpenDialogueConditionSO : Condition
{
    public override bool stateCondition(StateController controller)
    {
        return !controller.friendDialougue.noDialogue;
    }
}
