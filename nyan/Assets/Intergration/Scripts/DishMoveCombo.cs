using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DishMoveCombo : MonoBehaviour
{

    
    public List<GameObject> Slots = new List<GameObject>();
    List<bool> SlotsAvalible = new List<bool>();
    List<DishInfo> DishInfoL = new List<DishInfo>();
    public DishInfo dishInfo;
    void AWake()
    {
        for (int i = 0; i < 5; i++)
            SlotsAvalible.Add(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Clicked(GameObject gameObject)
    {
        int i = 0;
        int j = 0;
        foreach (DishInfo element in DishInfoL)
        {
            j++;
            if (element.gameObject == gameObject)
            {
                gameObject.transform.position = element.oldPosition;
                SlotsAvalible[j] = false;
                DishInfoL[j] = null;
            }
        }
        foreach (bool element in SlotsAvalible)
        {
            i++;
            if (element == true)
            {

                dishInfo.gameObject = gameObject;
                dishInfo.oldPosition = gameObject.transform.position;
                dishInfo.inSlot = true;
                dishInfo.indexPos = i;

                DishInfoL.Add(dishInfo);

                gameObject.transform.position = Slots[i].transform.position;

            }
        }
    }
}

[System.Serializable]
public class DishInfo
{
    public GameObject gameObject;
    public Vector3 oldPosition;
    public int indexPos;
    public bool inSlot;

}