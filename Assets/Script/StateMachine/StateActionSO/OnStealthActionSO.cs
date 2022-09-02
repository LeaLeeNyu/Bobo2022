using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OnStealthActionSO", menuName = "State Machine/Actions/OnStealthAction")]
public class OnStealthActionSO : StateAction
{
    public override void OnEnter(StateController controller)
    {
        //Enable Stealth Action Map => Stealth
        controller.boboInput.inputListener.EnableStealth();

        //Switch Animationm
        controller.boboAnimator.SetBool("stealth", true);
    }

    public override void OnExit(StateController controller)
    {

    }

    public override void Tick(StateController controller)
    {
        //Change collider hight and center
        controller.boboCollider.height = controller.boboAnimator.GetFloat("colliderHeight");
        float centerY = controller.boboAnimator.GetFloat("colliderCenter");
        controller.boboCollider.center = new Vector3(controller.boboCollider.center.x, centerY, controller.boboCollider.center.z);
    }

}
