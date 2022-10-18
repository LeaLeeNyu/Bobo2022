using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool gameIsEnd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Garden")
        {
            gameIsEnd = true;
            SceneManager.LoadScene("MissAccoplished");
        }
        //for checkPoint

    }
}
