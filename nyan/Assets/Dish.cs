using UnityEngine;

[System.Serializable]
public class Dish
{

    public string nameDish;
    public Sprite image;

    public int cost;

    public int popularity;

    // add 4 elements in inspector.
    public Sprite[] comboImages = new Sprite[4];

    public string _2x;
    public string _4x;

    public bool Instaciate = false;



}

