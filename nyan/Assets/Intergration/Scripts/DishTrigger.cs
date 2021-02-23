using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishTrigger : MonoBehaviour
{
    public GameObject con;
    public RectTransform container;
    public bool isOpen;
    public bool isHover = false;
    public float timer = 0.8f;

    private void Start()
    {
        container = con.GetComponent<RectTransform>();
    }


    void Update()
    {
        if (isHover)
        {
            timer -= 1 * Time.deltaTime;
        }
        if (timer <= 0)
        {
            isOpen = true;
            timer = 0;
        }

        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale;
        
    }

    public void HoverEnter()
    {
        isHover = true;
    }

    public void HoverExit()
    {
        isHover = false;
        isOpen = false;
        timer = 0.8f;

    }


}
