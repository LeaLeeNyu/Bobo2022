using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [HideInInspector]public bool diedAniEnd = false;
    [HideInInspector] public bool restartAniEnd = false;

    public void DiedAniEnd()
    {
        restartAniEnd = false;
        diedAniEnd = true;
        Debug.Log("DiedAniEnd");
    }

    public void RestartAniEnd()
    {
        restartAniEnd = true;
        diedAniEnd = false;
    }
}
