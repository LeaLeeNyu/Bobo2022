using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OnJumpAcionSO", menuName = "State Machine/Actions/OnJumpAcion")]
public class OnJumpActionSO : StateAction
{
    [SerializeField] private float jumpHeight = 2.0f;

    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float turnSmoothTime = 0.05f;
    [SerializeField] private float turnSmoothVelocity = default;

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
        Debug.Log("Exit jump");
        controller.boboEffect.DisableJumpParticles();
        controller.boboAnimator.SetBool("falling", true);
    }

    public override void Tick(StateController controller)
    {
        Movement(controller);
    }

    private void Movement(StateController controller)
    {
        float xMove = controller.boboInput.moveVectorInput.x;
        float zMove = controller.boboInput.moveVectorInput.y;
        Transform boboTransform = controller.gameObject.transform;
        Vector3 walkDirection = new Vector3(xMove, 0f, zMove).normalized;

        if (walkDirection.magnitude >= 0.1f)
        {
            // turn the chracter's face direction
            float targetAngle = Mathf.Atan2(walkDirection.x, walkDirection.z) * Mathf.Rad2Deg + controller.cameraTrans.eulerAngles.y;
            //smooth the rotation
            //the rotation angle should also calculate camera rotation angle
            float angle = Mathf.SmoothDampAngle(boboTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            boboTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 turnDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.boboRB.velocity = new Vector3(turnDir.normalized.x * walkSpeed, controller.boboRB.velocity.y, turnDir.normalized.z * walkSpeed);
        }
    }

}
