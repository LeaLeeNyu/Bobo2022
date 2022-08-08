using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleActionSO", menuName = "State Machine/Actions/IdleAction")]
public class IdleActionSO : StateAction
{
    public override void OnEnter(StateController controller)
    {
        controller.boboAnimator.SetBool("idle", true);
    }

    public override void OnExit(StateController controller)
    {
        controller.boboAnimator.SetBool("idle", false);
    }

    public override void Tick(StateController controller)
    {
        //throw new System.NotImplementedException();
    }
}
