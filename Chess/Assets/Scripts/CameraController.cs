using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float horizontalSpeed = 2.0f;

    //TODO Get peice selection working

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            transform.Rotate(0, h, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
