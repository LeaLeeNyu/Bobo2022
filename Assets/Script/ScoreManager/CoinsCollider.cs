using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollider : MonoBehaviour
{
    //collide with bobo, coin destory
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreManager.coinsCount += 1;
            Destroy(gameObject);
        }
    }
}
