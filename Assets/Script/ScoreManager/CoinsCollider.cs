using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollider : MonoBehaviour
{
    [SerializeField] private Wither wither;
    //collide with bobo, coin destory
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            ScoreManager.coinsCount += 1;

            if(this.tag == "PowerUp")
            {
                wither.witherTimer.timer += 0.1f;
            }

            Destroy(gameObject);
        }
    }


}
