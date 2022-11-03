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
    private float zoomInLimit = -3f;
    private float zoomOutLimit = -18f;

    //public Transform cube;
    void Start()
    {
        newPosition = transform.position;
        //Invoke(nameof(Test), 5f);
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
        newPosition.z = Mathf.Clamp(newPosition.z, zoomOutLimit, zoomInLimit);
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor);
    }

    public void FocusOn(Transform t)
    {
        newPosition = new Vector3(t.position.x, t.position.y, -10f);
    }

    //void Test()
    //{
    //    FocusOn(cube);
    //}
}
