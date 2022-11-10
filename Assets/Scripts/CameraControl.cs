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
    private float zoomInLimit = 4f;
    private float zoomOutLimit = 22f;

    public static CameraControl Instance;

    private void Awake()
    {
        Instance = this;
    }
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
            newPosition += (new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (new Vector3(0, 0, -speed * Time.deltaTime));
        }
        newPosition += new Vector3(0, Input.mouseScrollDelta.y * sensitivity, 0);
        //if (Input.mouseScrollDelta.y != 0)
            newPosition.y = Mathf.Clamp(newPosition.y, zoomInLimit, zoomOutLimit);
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor);
    }

    public void FocusOn(Transform t)
    {
        newPosition = new Vector3(t.position.x, zoomInLimit, t.position.z);
    }

    //void Test()
    //{
    //    FocusOn(cube);
    //}
}
