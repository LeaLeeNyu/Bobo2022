using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OnDialogueActionSO", menuName = "State Machine/Actions/OnDialogueAction")]
public class OnDialogueActionSO : StateAction
{
    public override void OnEnter(StateController controller)
    {
        controller.boboInput.inputListener.EnableUI();
    }

    public override void OnExit(StateController controller)
    {
        controller.boboInput.inputListener.EnableBasic();
    }

    public override void Tick(StateController controller)
    {
        
    }
}
