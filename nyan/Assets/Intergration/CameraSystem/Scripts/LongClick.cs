using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongClick : MonoBehaviour
{

    private float startTime, endTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 0f;
        endTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startTime = Time.time;

        if (Input.GetMouseButtonUp(0))
            endTime = Time.time;
        if(endTime - startTime > 0.5f)
        {

            Debug.Log("Long Click");
            GameObject spaceC = GameObject.Find("ClickController");
            spaceC.GetComponent<ClickController>().LongClick = true;

            startTime = 0f;
            endTime = 0f;



        }

    }
}
