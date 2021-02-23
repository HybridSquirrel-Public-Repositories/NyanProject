using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSys : MonoBehaviour
{


    public Material matBuild, matFail;
    public GameObject cam;
    private Transform ObjToMove;


    private GameObject cursurObject;
    public List<GameObject> ObjToPlace = new List<GameObject>();
   

    public LayerMask mask;


    public bool iscolliding = false;
    bool hoveringUI = false;
    bool placed = false;


    private int objectIndexer = 0;
    int LastPosX, LastPosY, LastPosZ;
    int PosX, PosY, PosZ;
    Vector3 mousePos;



    void OnEnable()
    {
        CursurChanger();    
    }

    void OnDisable()
    {
        Destroy(cursurObject);
    }

    // Update is called once per frame
    void Update() 
    {
        

        //Normal Raycast setup
        mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

     

        //Rounds the raycast value; Effect: Having a grid;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            PosX = (int)Mathf.Round(hit.point.x);
            PosY = (int)Mathf.Round(hit.point.y);
            PosZ = (int)Mathf.Round(hit.point.z);

        }

        //Updates Cursor/Object movement
        if (PosX != LastPosX || PosY != LastPosY || PosZ != LastPosZ)
        {
            LastPosX = PosX;
            LastPosY = PosY;
            LastPosZ = PosZ;
            ObjToMove.position = new Vector3(PosX, PosY + .32f, PosZ);

        }

        //Checks what object is selected
        if(cursurObject.GetComponent<BuildingCursur>().ID != objectIndexer)
        {

            CursurChanger();
            

        }
                                        
        //Building the object
        if (Input.GetMouseButton(0))
        {

            if (!iscolliding && !placed && !hoveringUI)
            {

                GameObject building = Instantiate(ObjToPlace[objectIndexer], ObjToMove.position, Quaternion.identity);
                placed = true;


            }

            
        }
        if (Input.GetMouseButtonUp(0))
        {
            placed = false;
            
        }
    }







    void CursurChanger() //Replaces the cursor 
    {

        Destroy(cursurObject);

        cursurObject = Instantiate(ObjToPlace[objectIndexer], new Vector3(0, 0, 0), Quaternion.identity);
        cursurObject.name = "Curcur";
        cursurObject.layer = 30;

        var BC = cursurObject.AddComponent<BuildingCursur>();
        var RG = cursurObject.AddComponent<Rigidbody>();

        BC.ID = objectIndexer;
        cursurObject.GetComponent<Renderer>().material = matBuild;
        BC.matBuild = matBuild;
        BC.matFail = matFail;
        BC.cam = cam;

        RG.useGravity = false;
        RG.constraints = RigidbodyConstraints.FreezeAll;
        RG.collisionDetectionMode = CollisionDetectionMode.Continuous;

        ObjToMove = cursurObject.transform;
        
    }
    





    public void SetMain() //Sets to a diffrent building
    {
        objectIndexer = 0;
    }

    public void SetKitchen() //Sets to a diffrent building 
    {
        objectIndexer = 1;

    }

    public void SetDining()
    {
        objectIndexer = 2;
    }

    public void SetEmety()
    {
        objectIndexer = 3;
    }

    public void HoverEnter() //If cursor is hovering above a button
    {

        hoveringUI = true;
        cursurObject.SetActive(false);

    }

    public void HoverExit() //If cursor is not hovering above a button
    {

        hoveringUI = false;
        cursurObject.SetActive(true);
        
    }





}
