using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Transform Rot;
    public float lookSens;
    public float minX, maxX;
    private float curXRot;

   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Look();

        }
        
    }

    private void Look()
    {
        float x = Input.GetAxis("Mouse Y") * lookSens;
        float y = Input.GetAxis("Mouse X") * lookSens;
        x = Mathf.Clamp(x, minX, maxX);

        curXRot += x;
        curXRot = Mathf.Clamp(curXRot, minX, maxX);
        Rot.localEulerAngles = new Vector3(-curXRot, 90, 0);

        
        transform.eulerAngles += Vector3.up * y;
        transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.3f);

    }


}
