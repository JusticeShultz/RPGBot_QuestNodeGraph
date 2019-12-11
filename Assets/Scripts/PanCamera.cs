using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public Camera cam;

    private Vector3 target = new Vector3(0, 0, -10);

    Vector3 lastPos = Vector3.zero;

    void Update()
    {
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2) || (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl)))
        {
            target += lastPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - (Input.mouseScrollDelta.y / 2), 1, 50);

        if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.LeftControl))
        {
            target = new Vector3(0, 0, -10);
            cam.orthographicSize = 5;
        }

        lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    } 
}