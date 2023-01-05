using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    public static bool countTime = false;
    public static float levelTime;
    void Start()
    {
        levelTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime)
        {
            levelTime += Time.deltaTime;
        }
        
    }
}
