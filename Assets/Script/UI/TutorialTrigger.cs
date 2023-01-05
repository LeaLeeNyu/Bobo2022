using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private Wither wither;
    [SerializeField] private Animator animatorUI;
    private void OnTriggerEnter(Collider other)
    {
        //If collider is player and player is not died
        if (other.gameObject.tag == "Player" && !wither.died && !wither.aniController.diedAniStart)
        {
            animatorUI.Play("Trigger");
        }
    }
}
