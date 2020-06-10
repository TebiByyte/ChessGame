using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    private float yaw;
    private float pitch;

    //TODO Get peice selection working

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            yaw += horizontalSpeed * Input.GetAxis("Mouse X");

            if (pitch < 90 && pitch > -90) {
                pitch += verticalSpeed * Input.GetAxis("Mouse Y");
            }
            else
            {
                pitch = Mathf.Sign(pitch) * 89.9f;
            }

            Cursor.lockState = CursorLockMode.Locked;
            transform.eulerAngles = new Vector3(pitch, yaw, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
