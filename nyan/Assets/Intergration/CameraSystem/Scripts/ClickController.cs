using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{



    //float speed = 0.0f;
    public bool LongClick = false;
    public bool DoubleClick = false;
    public GameObject CameraPivot;
    GameObject BuildCam;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (DoubleClick)
        {
            
            DoubleClick = false;
            CameraPivot.transform.position = new Vector3(0, 0, 0);

            
        }

        if(LongClick)
        {
            var _EventSys = GameObject.Find("EventSystem").GetComponent<EventScript>();
            if (_EventSys.currentState == EventScript.stateUI.BuildMode)
            {
                var _CursurSys = GameObject.Find("Curcur").GetComponent<BuildingCursur>();

                Destroy(_CursurSys.GetCollision());
                _CursurSys.TriggerCamFalse();

                LongClick = false;


            }
        }


    }
}
