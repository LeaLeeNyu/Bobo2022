using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateAction :ScriptableObject
{
    public abstract void Tick(StateController controller);
    public abstract void OnEnter(StateController controller);
    public abstract void OnExit(StateController controller);
}
