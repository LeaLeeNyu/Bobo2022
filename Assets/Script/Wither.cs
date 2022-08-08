using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wither : MonoBehaviour
{
    private float witherTime =5f;
    private FunctionTimer witherTimer;

    private bool startWither = false;
    [HideInInspector]public bool died = false;

    public Material leafColor;
    public Color yellowLeaf;
    public Color greenLeaf;

    private void Awake()
    {
        witherTimer = new FunctionTimer(Withered, witherTime);
    }

    private void Update()
    {
        if (startWither)
        {
            witherTimer.UpdateTimer();
            //Debug.Log(witherTimer.timer);

            //change leaves color by time
            float colorTime = Map(witherTimer.timer, 0f, witherTime, 1f, 0f);
            leafColor.color = Color.Lerp(greenLeaf, yellowLeaf, colorTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //if bobo collide with the dirt
            //stop the timer and reset the time
            startWither = false;
            witherTimer.ResetSelf(witherTime);
            leafColor.color = greenLeaf;
        }
        else
        {
            startWither = true;
        }
    }

    private void Withered()
    {
        died = true;
    }

    private float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
}
