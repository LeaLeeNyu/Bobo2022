using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

[CreateAssetMenu(fileName = "JumpDescendSO", menuName = "State Machine/Actions/JumpDescend")]
public class JumpDescendActionSO : StateAction
{
    //[SerializeField] private float jumpHeight = 2.0f;

    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float turnSmoothTime = 0.05f;
    [SerializeField] private float turnSmoothVelocity = default;
    [SerializeField] private float jumpHeight = 2.0f;

    public override void OnEnter(StateController controller)
    {
        controller.boboAnimator.SetBool("jumping", false);
    }

    public override void OnExit(StateController controller)
    {
        Debug.Log("Exit jumpDescend");
        controller.boboEffect.EnableLandingParticles();
        controller.boboAnimator.SetBool("falling", false);
    }

    public override void Tick(StateController controller)
    {
        //boboRB.velocity += Vector3.up * Physics.gravity.y * (jumpHeight - 1f);

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
