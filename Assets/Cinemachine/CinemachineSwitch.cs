using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitch : MonoBehaviour
{
    private Animator camAnimator;
    [SerializeField] private DialogueSystem friendDialogue;
    [SerializeField] private ScoreManager scoreManager;

    void Start()
    {
        camAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
    }


    void SwitchCamera()
    {
        //If there is Dialogue
        //If player finish the level
        if (scoreManager.gameEnd)
        {
            camAnimator.Play("FinishCamera");
        }
        else if (!friendDialogue.noDialogue)
        {
            camAnimator.Play("DialogueCamera");
        }
        else
        {
            camAnimator.Play("ThirdPersonCamera");
        }


    }
}
