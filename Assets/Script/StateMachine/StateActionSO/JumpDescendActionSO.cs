using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpDescendSO", menuName = "State Machine/Actions/JumpDescend")]
public class JumpDescendActionSO : StateAction
{
    //[SerializeField] private float jumpHeight = 2.0f;

    public override void OnEnter(StateController controller)
    {       
        controller.boboAnimator.SetBool("falling", true);
    }

    public override void OnExit(StateController controller)
    {
        controller.boboEffect.EnableLandingParticles();
        //controller.boboEffect.DisableLandingParticles();
        controller.boboAnimator.SetBool("falling", false);
    }

    public override void Tick(StateController controller)
    {
        //controller.boboRB.velocity += Vector3.up * Physics.gravity.y * (jumpHeight - 1f);
    }
}
