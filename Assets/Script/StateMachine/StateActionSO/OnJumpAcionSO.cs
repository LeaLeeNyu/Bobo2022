using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OnJumpAcionSO", menuName = "State Machine/Actions/OnJumpAcion")]
public class OnJumpAcionSO : StateAction
{
    [SerializeField] private float jumpHeight = 2.0f;

    public override void OnEnter(StateController controller)
    {
        controller.boboRB.velocity = new Vector3(controller.boboRB.velocity.x, jumpHeight);
        //Particle Effect
        controller.boboEffect.EnableJumpParticles();
        //Animator
        controller.boboAnimator.SetBool("jumping", true);
    }

    public override void OnExit(StateController controller)
    {
        controller.boboEffect.DisableJumpParticles();
        controller.boboAnimator.SetBool("jumping", false);      
    }

    public override void Tick(StateController controller)
    {
        
    }
}
