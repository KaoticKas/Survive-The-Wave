using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMouse : MonoBehaviour
{


    private Camera mainCam;
    // Use this for initialization
    void Start()
    {
        mainCam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, this.transform.position.y, 0));
        float rayLen;

        if (groundPlane.Raycast(camRay, out rayLen))
        {
            Vector3 pointToLook = camRay.GetPoint(rayLen);

            Debug.DrawLine(camRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, pointToLook.y, pointToLook.z));

        }
    }
}
