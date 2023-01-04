using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wither : MonoBehaviour
{
    private float witherTime =5f;
    [HideInInspector] public float witherTimeLength;
    [HideInInspector] public FunctionTimer witherTimer;

    //relate wirh stealth behaviour
    [HideInInspector] public bool collideGround;

    private bool startWither = false;
    [HideInInspector]public bool died = false;

    public Material leafColor;
    public Color yellowLeaf;
    public Color greenLeaf;
    [HideInInspector] public float colorTime =1f;

    //OnGround Detect
    [SerializeField]private Transform groundCheck;
    [SerializeField]private float groundCheckRadius =0.1f;

    //Animator Controller
    public AnimationController aniController;

    private void Awake()
    {
        //Create a timer
        witherTimeLength = witherTime;
        witherTimer = new FunctionTimer(Withered, witherTime);
        startWither = false;
        leafColor.color = greenLeaf;
    }

    private void Update()
    {
        DetectCollider();

        if (startWither && !died && !aniController.diedAniStart)
        {
            //change leaves color by time
            colorTime = Map(witherTimer.timer, 0f, witherTime, 1f, 0f);
            leafColor.color = Color.Lerp(greenLeaf, yellowLeaf, colorTime);

            witherTimer.UpdateTimer();
            //Debug.Log(witherTimer.timer);
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
            }
            //if bobo collide with dirt, reset the timer
            else if(collider.gameObject.tag == "Ground")
            {
                collideGround = true;
                startWither = false;
               

                //reset bobo leaf color 
                if (!died && !aniController.diedAniStart)
                {
                    witherTimer.ResetSelf(witherTime);
                    colorTime = Map(witherTimer.timer, 0f, witherTime, 1f, 0f);
                    leafColor.color = greenLeaf;
                    Debug.Log("reset");
                }                
            }
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
