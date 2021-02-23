using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCameraScript : MonoBehaviour
{


    public float panSpeed = 20f;
    public float panBorderThickness = 20f;
    bool CameraDisabled = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKeyDown(KeyCode.Mouse2))
            CameraDisabled = !CameraDisabled;

        if (!CameraDisabled)
        {
            if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                pos.z += panSpeed * Time.deltaTime;
            }

            if (Input.mousePosition.y <= panBorderThickness)
            {
                pos.z -= panSpeed * Time.deltaTime;
            }

            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos.x += panSpeed * Time.deltaTime;
            }

            if (Input.mousePosition.x <= panBorderThickness)
            {
                pos.x -= panSpeed * Time.deltaTime;

            }

            transform.position = pos;

        }
    }
}
