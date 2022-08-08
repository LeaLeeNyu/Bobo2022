using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IsMovingConditionSO",menuName = "State Machine/Condition/IsMoving")]
public class IsMovingConditionSO : Condition
{
    private BoboInput boboInput;
    public float trehold = 0.1f;

    public override bool stateCondition(StateController controller)
    {
        boboInput = controller.boboInput;
        return isMove(boboInput); 
         
    }

    private bool isMove(BoboInput boboInput)
    {
        Vector2 moveInput = boboInput.moveVectorInput;
        return moveInput.magnitude > trehold;
    }

}
