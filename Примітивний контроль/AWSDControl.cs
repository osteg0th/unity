using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWSDControl : MonoBehaviour {

    public float speed = 1f;
	
	void Update () {
        //if(Input.GetAxis("Horizontal")>0)
        //    transform.Translate(transform.right * speed);
        //if (Input.GetAxis("Horizontal") < 0)
        //    transform.Translate(-transform.right * speed);
        if (Input.GetButton("MoveRight"))
            transform.Translate(transform.right * speed);
        if (Input.GetButton("MoveLeft"))
            transform.Translate(-transform.right * speed);
        if (Input.GetButton("MoveForward"))
            transform.Translate(transform.forward * speed);
        if (Input.GetButton("MoveBack"))
            transform.Translate(-transform.forward * speed);
        if (Input.GetButton("Jump"))
            transform.Translate(transform.up * speed);
    }
}
