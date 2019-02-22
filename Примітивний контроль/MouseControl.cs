using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour {

    public float sensitiveX = 1f;
    public float sensitiveY = 1f;

    public float minX = -360;
    public float maxX = 360;
    public float maxY = 90;
    public float minY = -90;
    Quaternion originalRot;
    float rotX = 0;
    float rotY = 0;
    // Use this for initialization
    void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb)
        {
            rb.freezeRotation = true; 
        }
        originalRot = transform.localRotation; 
	}
	
	// Update is called once per frame
	void Update () {
        rotX += Input.GetAxis("Mouse X") * sensitiveX;
        rotY += Input.GetAxis("Mouse Y") * sensitiveY;

        rotX %= 360;
        rotY %= 360;

        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);

        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);
        transform.localRotation = originalRot * xQuaternion * yQuaternion; 


    }
}
