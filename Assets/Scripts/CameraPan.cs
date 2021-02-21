using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    // Min and max FOV for zoom
    private float minZoom  = 15f;
    private float maxZoom  = 200f;
    private float zoomSpeed = 200f;

    [SerializeField]
    private float panSpeed = 50f, screenBorder = 20f, scrollSpeed = 5f;
    [SerializeField]
    private Vector2 movLimit;

    private Vector2 mousePos;
    private float scroll;

    void Update()
    {
        CameraZoom();
        GetInput();
        Vector3 camPos = transform.position;
        if (mousePos.y >= Screen.height - screenBorder) //camera forward
        {
            camPos.x += panSpeed * Time.deltaTime;
        }
        if (mousePos.y <= screenBorder)// camera backward
        {
            camPos.x -= panSpeed * Time.deltaTime;
        }
        if (mousePos.x >= Screen.width - screenBorder)//camera right
        {
            camPos.z -= panSpeed * Time.deltaTime;
        }
        if (mousePos.x <= screenBorder) // camera left
        {
            camPos.z += panSpeed * Time.deltaTime;
        }
        // To add a limit to movement in the map
        //camPos.x = Mathf.Clamp(camPos.x, -movLimit.x, movLimit.x);
        //camPos.y = Mathf.Clamp(camPos.z, -movLimit.y, movLimit.y);
        transform.position = camPos;
    }
    private void GetInput()
    {
        mousePos = Input.mousePosition;
    }

    private void CameraZoom()
    {
        Vector3 zoom = transform.position;
        
        // Check to see if we go outside our min/max zoom
        if (zoom.y < minZoom)
        {
            zoom.y = minZoom;
            transform.position = zoom;
        }
        if (zoom.y > maxZoom)
        {
            zoom.y = maxZoom;
            transform.position = zoom;
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoom.y < maxZoom)
            {
                transform.Translate(Vector3.back * Time.deltaTime * zoomSpeed);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoom.y > minZoom)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * zoomSpeed);
            }
        }
    }


}
