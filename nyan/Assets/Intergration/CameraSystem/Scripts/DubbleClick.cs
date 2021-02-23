using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DubbleClick : MonoBehaviour
{
    private float firstClickTime, timeBetweenClicks;
    private bool coroutlineAllowed;
    private int clickCounter;


    // Start is called before the first frame update
    void Start()
    {
        firstClickTime = 0f;
        timeBetweenClicks = 0.2f;
        clickCounter = 0;
        coroutlineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
            clickCounter += 1;

        if (clickCounter == 1 && coroutlineAllowed)
        {
            firstClickTime = Time.time;
            StartCoroutine(DoubleClickDetection());
        }



    }
    private IEnumerator DoubleClickDetection()
    {
        coroutlineAllowed = false;
        while(Time.time < firstClickTime + timeBetweenClicks)
        {
            if(clickCounter == 2)
            {
                Debug.Log("Double click");

                GameObject spaceC = GameObject.Find("ClickController");
                spaceC.GetComponent<ClickController>().DoubleClick = true;

                break;
            }
            yield return new WaitForEndOfFrame();
        }
        clickCounter = 0;
        firstClickTime = 0f;
        coroutlineAllowed = true;
    }

}
