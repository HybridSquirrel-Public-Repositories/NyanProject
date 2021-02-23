using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCursur : MonoBehaviour
{
    public Material matFail, matBuild;
    public GameObject cam;
    Renderer rend;
    public int ID;

    GameObject col;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame


    void OnCollisionEnter(Collision collision)
    {



        col = collision.gameObject;
        
        TriggerCamTrue();        
    }

    private void OnCollisionStay(Collision collision)
    {
        TriggerCamTrue();
    }


    void OnCollisionExit(Collision collision)
    {


        col = null;

        TriggerCamFalse();
        

    }


    public GameObject GetCollision()
    {
        return col;

    }



    public void TriggerCamFalse() //If cursor not colliding with a building
    {
        rend.material = matBuild;
        cam.GetComponent<BuildingSys>().iscolliding = false;
    }

    public void TriggerCamTrue() //If cursor colliding with a building
    {
        rend.material = matFail; //throw an error dont know why, it works in the editor :/
        cam.GetComponent<BuildingSys>().iscolliding = true;

    }

    

}
