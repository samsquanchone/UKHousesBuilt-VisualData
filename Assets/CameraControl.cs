using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 50f;
    private float sensitivity = 2f;
    private Vector3 newPosition = Vector3.zero;
    private float smoothFactor = 0.05f;
    private float zoomLimit = 10f;
    void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (new Vector3(0, speed * Time.deltaTime, 0));
        }
        newPosition += new Vector3(0, 0, Input.mouseScrollDelta.y * sensitivity);
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor);
    }
}
