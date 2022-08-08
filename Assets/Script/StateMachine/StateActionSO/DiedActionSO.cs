using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiedActionSO", menuName = "State Machine/Actions/DiedAction")]
public class DiedActionSO : StateAction
{
    public override void OnEnter(StateController controller)
    {
        //Ani
        controller.boboAnimator.SetBool("died", true);
        //died
        controller.wither.died = false;
        Debug.Log("Enter the died state");
    }

    public override void OnExit(StateController controller)
    {
        controller.boboAnimator.SetBool("died", false);
    }

    public override void Tick(StateController controller)
    {
        
    }
}
