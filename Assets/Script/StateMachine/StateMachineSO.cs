using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStateMachine", menuName = "State Machine/StateMachineSO")]
public class StateMachineSO:ScriptableObject
{
    public StateSO originalState;
    public StateSO currentState;
    //public StateSO remainInState;
    [SerializeField] private Transition[] _anytransition;

    public void Tick(StateController controller)
    {
        Transition transition = GetTransition(controller);

        if(transition != null)
            SetState(transition.toState, controller);

        currentState?.stateAction.Tick(controller);

    }

    private void SetState(StateSO toState,StateController controller)
    {
        if (toState == currentState)
        {
            return;
        }

        currentState?.stateAction.OnExit(controller);

        currentState = toState;
        currentState.stateAction.OnEnter(controller);
           
    }

    private Transition GetTransition(StateController controller)
    {
        Transition[] currentTransitions = currentState.transitions;

        foreach (Transition transition in _anytransition)
        {
            if (transition.condition.stateCondition(controller)== expectedResult(transition))
            {
                return transition;
            }
        }


        foreach(Transition transition in currentTransitions)
        {
            if (transition.condition.stateCondition(controller) == expectedResult(transition))
            {
                return transition;
            }
        }

        return null;
    }

    private bool expectedResult(Transition transition)
    {
        if (transition.expectedResult == Transition.ExpectedResult.True)
        {
            transition.result = true;
        }
        else if (transition.expectedResult == Transition.ExpectedResult.False)
        {
            transition.result = false;
        }

        return transition.result;
    }
}
