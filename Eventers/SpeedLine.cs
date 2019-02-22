using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLine : MonoBehaviour {

    public float speed = 20f;
	void OnTriggerStay(Collider info)
    {
        if (info.name == "Player")
            FindObjectOfType<PlayerMovement>().playerRB.AddForce(0, 0, speed * Time.fixedDeltaTime, ForceMode.Impulse); 
    }
}
