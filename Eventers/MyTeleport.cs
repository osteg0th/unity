using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTeleport : MonoBehaviour {

    public Transform teleportExit;
    void OnTriggerEnter(Collider info)
    {
        if (info.name == "Player")
            info.transform.position = teleportExit.position;
    }
}
