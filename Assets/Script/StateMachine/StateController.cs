using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public StateMachineSO boboStateMachine;

    //parameter that pass to states
    [HideInInspector] public BoboInput boboInput;
    [HideInInspector] public Animator boboAnimator;
    [HideInInspector] public Rigidbody boboRB;
    [HideInInspector] public EffectController boboEffect;
    [HideInInspector] public Wither wither;
    [HideInInspector] public AnimationController aniController;
    [HideInInspector] public CapsuleCollider boboCollider;
    public DialogueSystem friendDialougue;
    public ScoreManager scoreManager;
    public Transform cameraTrans;

    [SerializeField] private StateSO _currentState;


    private void Awake()
    {
        boboInput = GetComponent<BoboInput>();
        boboAnimator = GetComponent<Animator>();
        boboRB = GetComponentInParent<Rigidbody>();
        boboEffect = GetComponent<EffectController>();
        wither = GetComponent<Wither>();
        aniController = GetComponent<AnimationController>();
        boboCollider = GetComponent<CapsuleCollider>(); 
        boboStateMachine.currentState = boboStateMachine.originalState;
    }

    private void Update()
    {
        boboStateMachine.Tick(this);
        _currentState = boboStateMachine.currentState;     
    }


}
