using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FinishActionSO", menuName = "State Machine/Actions/FinishAction")]
public class FinishActionSO : StateAction
{
    public override void OnEnter(StateController controller)
    {
        controller.boboAnimator.SetBool("gameEnd", true);
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
