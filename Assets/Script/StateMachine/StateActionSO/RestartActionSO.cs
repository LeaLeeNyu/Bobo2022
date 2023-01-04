using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RestartActionSO", menuName = "State Machine/Actions/RestartAction")]
public class RestartActionSO : StateAction
{
    public override void OnEnter(StateController controller)
    {
        //Load the checkPoint Position
        PlayerData data = SaveSystem.LoadData();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        controller.gameObject.transform.position = position;

        //Leaf color
        //controller.wither.leafColor.color = controller.wither.greenLeaf;

        //Ani
       // controller.boboAnimator.SetBool("diedAniStart", false);
        controller.boboAnimator.SetBool("restart", true);
    }

    public override void OnExit(StateController controller)
    {
        //Ani
        controller.boboAnimator.SetBool("restart", false);
        controller.boboAnimator.SetBool("jumping", false);
        controller.boboAnimator.SetBool("falling", false);
    }

    public override void Tick(StateController controller)
    {
        
    }
}
