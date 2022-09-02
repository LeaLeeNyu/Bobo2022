using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StealthMovingActionSO", menuName = "State Machine/Actions/StealthMovingAction")]
public class StealthMovingActionSO : StateAction
{
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float turnSmoothTime = 0.05f;
    [SerializeField] private float turnSmoothVelocity = default;
    public override void OnEnter(StateController controller)
    {
        controller.boboAnimator.SetBool("stealthMoving",true);
    }

    public override void OnExit(StateController controller)
    {
        controller.boboAnimator.SetBool("stealthMoving", false);
    }

    public override void Tick(StateController controller)
    {
        Movement(controller);
    }

    private void Movement(StateController controller)
    {
        float xMove = controller.boboInput.stealthMoveVectorInput.x;
        float zMove = controller.boboInput.stealthMoveVectorInput.y;
        Transform boboTransform = controller.gameObject.transform;
        Vector3 moveDirection = new Vector3(xMove, 0f, zMove).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            // turn the chracter's face direction
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + controller.cameraTrans.eulerAngles.y;
            //smooth the rotation
            //the rotation angle should also calculate camera rotation angle
            float angle = Mathf.SmoothDampAngle(boboTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            boboTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 turnDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.boboRB.velocity = new Vector3(turnDir.normalized.x * walkSpeed, controller.boboRB.velocity.y, turnDir.normalized.z * walkSpeed);
        }
    }
}
