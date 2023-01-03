using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wither : MonoBehaviour
{
    private float witherTime =5f;
    [HideInInspector]public FunctionTimer witherTimer;

    [HideInInspector] public bool collideGround;
    private bool startWither = false;
    [HideInInspector]public bool died = false;

    public Material leafColor;
    public Color yellowLeaf;
    public Color greenLeaf;

    //OnGround Detect
    [SerializeField]private Transform groundCheck;
    [SerializeField]private float groundCheckRadius =0.1f;

    private void Awake()
    {
        //Create a timer
        witherTimer = new FunctionTimer(Withered, witherTime);
        startWither = false;
        leafColor.color = greenLeaf;
    }

    private void Update()
    {
        DetectCollider();

        if (startWither)
        {
            witherTimer.UpdateTimer();
            //Debug.Log(witherTimer.timer);

            //change leaves color by time
            float colorTime = Map(witherTimer.timer, 0f, witherTime, 1f, 0f);
            leafColor.color = Color.Lerp(greenLeaf, yellowLeaf, colorTime);
        }
    }

    private void DetectCollider()
    {
        Collider[] hitColliders = Physics.OverlapSphere(groundCheck.position, groundCheckRadius);
        foreach(Collider collider in hitColliders)
        {
            if(collider.gameObject.tag == "WitherGround")
            {
                collideGround = false;
                startWither = true;
            }else if(collider.gameObject.tag == "Ground")
            {
                collideGround = true;
                startWither = false;
                witherTimer.ResetSelf(witherTime);
                if (!died)
                {
                    leafColor.color = greenLeaf;
                }                
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        Debug.Log("Ground");
    //        //if bobo collide with the dirt
    //        //stop the timer and reset the time
    //        collideGround = true;
    //        startWither = false;
    //        witherTimer.ResetSelf(witherTime);
    //        leafColor.color = greenLeaf;
    //    }
    //    else
    //    {
    //        collideGround = false;
    //        startWither = true;
    //    }
    //}

    private void Withered()
    {
        died = true;
    }

    private float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
}
