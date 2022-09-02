using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StealthQuitActionSO", menuName = "State Machine/Actions/StealthQuitAction")]
public class StealthQuitActionSO : StateAction
{
    public override void OnEnter(StateController controller)
    {
        controller.boboAnimator.SetBool("stealth", false);
    }

    public override void OnExit(StateController controller)
    {
        controller.boboInput.inputListener.EnableBasic();
    }

    public override void Tick(StateController controller)
    {
        //Change collider hight and center
        controller.boboCollider.height = controller.boboAnimator.GetFloat("colliderHeight");
        float centerY = controller.boboAnimator.GetFloat("colliderCenter");
        controller.boboCollider.center = new Vector3(controller.boboCollider.center.x, centerY, controller.boboCollider.center.z);
    }
}
