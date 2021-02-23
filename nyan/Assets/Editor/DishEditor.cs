using UnityEngine;
using UnityEditor;




[CustomEditor(typeof(DishScript))]
public class DishEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DishScript dishScript = (DishScript)target;

        if (GUILayout.Button("Create C_Dish"))
        {
            dishScript.CreateClass();
        }

        if (GUILayout.Button("Remove C_Dish"))
        {
            dishScript.RemoveClass();
        }





    }

}