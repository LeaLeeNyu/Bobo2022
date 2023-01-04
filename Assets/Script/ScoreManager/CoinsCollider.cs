using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollider : MonoBehaviour
{
    [SerializeField] private Wither wither;
    //collide with bobo, coin destory
    private void OnTriggerEnter(Collider other)
    {
        //If collider is player and player is not died
        if(other.gameObject.tag == "Player" && !wither.died && !wither.aniController.diedAniStart)
        {
            ScoreManager.coinsCount += 1;

            //if the coin is a special power up, add time
            if(this.tag == "PowerUp" && wither.witherTimer.timer+1f< wither.witherTimeLength)
            {
                wither.witherTimer.timer += 1f;
            }else if(this.tag == "PowerUp")
            {
                wither.witherTimer.timer = wither.witherTimeLength;
            }

            Destroy(gameObject);
        }
    }


}
