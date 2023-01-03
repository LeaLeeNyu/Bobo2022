using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingPoint : MonoBehaviour
{
    [HideInInspector]public Vector3 checkPointPos;
    [SerializeField] private Transform checkPointTransform;

    protected virtual void Awake()
    {
        checkPointPos = checkPointTransform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //If player arrive at this check point, next time player died, they will reborn at this check point
            SaveSystem.SavePlayer(this);
            //Debug.Log("checking point");
        }
    }


}
