using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapActionSO", menuName = "State Machine/Actions/MapAction")]
public class MapActionSO : StateAction
{
    public override void OnEnter(StateController controller)
    {
        //Open the map
        if(controller.cameraLook.mapName == "Map1")
        {
            controller.mapManager.map1.SetActive(true);           
        }else if(controller.cameraLook.mapName == "Map2")
        {
            controller.mapManager.map2.SetActive(true);
        }else if (controller.cameraLook.mapName == "Map3")
        {
            controller.mapManager.map3.SetActive(true);
        }else if(controller.cameraLook.mapName == "Map4")
        {
            controller.mapManager.map4.SetActive(true);
        }

    }

    public override void OnExit(StateController controller)
    {
        if (controller.cameraLook.mapName == "Map1")
        {
            controller.mapManager.map1.SetActive(false);
        }
        else if (controller.cameraLook.mapName == "Map2")
        {
            controller.mapManager.map2.SetActive(false);
        }
        else if (controller.cameraLook.mapName == "Map3")
        {
            controller.mapManager.map3.SetActive(false);
        }
        else if (controller.cameraLook.mapName == "Map4")
        {
            controller.mapManager.map4.SetActive(false);
        }

        controller.cameraLook.lookMap = false;
    }

    public override void Tick(StateController controller)
    {
        
    }
}
