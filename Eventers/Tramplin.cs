using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramplin : MonoBehaviour {
    Rigidbody rb;
    public float jumperPower = 20f;
    
    void OnCollisionEnter(Collision info)
    {
        if (info.collider.name == "Player")
        { 
            FindObjectOfType<PlayerMovement>().playerRB.AddForce(0, 0, jumperPower * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
    void OnCollisionStay(Collision info)
    {
        if (info.collider.name == "Player")
            info.collider.GetComponent<Rigidbody>().freezeRotation = true;
    }
    void OnCollisionExit(Collision info)
    {
        if (info.collider.name == "Player")
            info.collider.GetComponent<Rigidbody>().freezeRotation = false;
    }
}

