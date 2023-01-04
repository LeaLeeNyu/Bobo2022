using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public bool diedAniEnd = false;
    [HideInInspector] public bool restartAniEnd = false;

    //relate to bobo's leaf color change when it diedAniStart and collide with dirt ground
     public bool diedAniStart = false;

    public void DiedAniStart()
    {
        diedAniStart = true;
        Debug.Log("DiedAniStart");
    }

    public void DiedAniEnd()
    {
        restartAniEnd = false;
        diedAniEnd = true;
        diedAniStart = false;
        Debug.Log("DiedAniEnd");
    }

    public void RestartAniEnd()
    {
        restartAniEnd = true;
        diedAniEnd = false;
        
    }
}
