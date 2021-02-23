using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DishScript : MonoBehaviour
{
    [System.NonSerialized]
    public Vector3 pos = new Vector3(0, 38, 0);
    public int index = 0;



    public GameObject Dishtab;

    public List<Dish> dishList = new List<Dish>();

    
    public List<GameObject> dishTab = new List<GameObject>();


    public void CreateClass()
    {
        //move CreateDropDown() here and add UI Gameobject to a list with an auto pos that adjusts itself. 
        dishList.Add(new Dish());

    }

    public void RemoveClass()
    {
        var index = dishList.Count;

        dishList.RemoveAt(index - 1);

    }



    void Update()
    {
       

        foreach (Dish dish in dishList)//make for loop
        {

            //creates
            if (dish.Instaciate)
            {
                dish.Instaciate = false;


                List<GameObject> _objects = new List<GameObject>();
                GameObject obj = Dishtab;


                //gets all the needed components
                foreach (Transform child in obj.transform)
                {
                    _objects.Add(child.gameObject);
                    

                }

                for (int i = 0; i < _objects.Count; i++)
                {
                    foreach (Transform child_2 in _objects[i].transform)
                    {
                        _objects.Add(child_2.gameObject);

                    }

                }

                
                obj.name = dishList[index].nameDish;
                Debug.Log(obj.name);

                _objects[3].GetComponent<Button>();
                // fix get component 
                _objects[4].GetComponent<TextMeshProUGUI>().text = dish._2x;
                _objects[5].GetComponent<TextMeshProUGUI>().text = dish._4x;


                //Add Logos on DishTab
                _objects[6].GetComponent<Image>().sprite = dish.comboImages[0];
                _objects[7].GetComponent<Image>().sprite = dish.comboImages[1];
                _objects[8].GetComponent<Image>().sprite = dish.comboImages[2];
                _objects[9].GetComponent<Image>().sprite = dish.comboImages[3];

                _objects[10].GetComponent<Image>().sprite = dish.image;
                _objects[11].GetComponent<TextMeshProUGUI>().text = dish.nameDish;
                _objects[12].GetComponent<TextMeshProUGUI>().text = "Pop: " + dish.popularity.ToString() + "$";
                _objects[13].GetComponent<TextMeshProUGUI>().text = "Cost: " + dish.cost.ToString();

                GameObject.Instantiate(obj, this.transform);

                
                
                dishTab.Add(obj);
                dishTab[index].transform.localPosition = pos;
                pos -= new Vector3(0, 48, 0);
                index += 1;
                
                
            }
        }
    }
}




   

