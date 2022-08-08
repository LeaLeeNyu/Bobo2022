using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newState",menuName ="State Machine/StateSO")]
public class StateSO : ScriptableObject
{
    //StateAction:OnExit,OnEnter,Tick
    public StateAction stateAction;

    //transitions:toState,Condition
    public Transition[] transitions;    
}
