using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {

    public float jumperPower=20f;
	void OnTriggerEnter(Collider info)
    {
        if (info.name == "Player")
            FindObjectOfType<PlayerMovement>().playerRB.AddForce(0, jumperPower*Time.fixedDeltaTime, 0, ForceMode.Impulse); 
    }
}
