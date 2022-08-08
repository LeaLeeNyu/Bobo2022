using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition
{
    public Condition condition;
    public ExpectedResult expectedResult;
    public enum ExpectedResult{True,False};
    public StateSO toState;
    [HideInInspector] public bool result;
}
