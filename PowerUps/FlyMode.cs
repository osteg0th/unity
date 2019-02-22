using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMode : MonoBehaviour {

    public float duration= 2f;
    public GameObject powerUpEfect;
    GameObject player;
    void OnTriggerEnter(Collider info)
    {
        if(info.name == "Player")
        {
            player = info.gameObject;
            PowerUp();
        }
    }
    void PowerUp()
    {
        Destroy(Instantiate(powerUpEfect, transform.position, transform.rotation), 1f);
        if (FindObjectOfType<PlayerState>().flyMode)
        {
            duration *= 2;
        }
        else
        {
            FindObjectOfType<PlayerState>().flyMode = true;
            FindObjectOfType<PlayerMovement>().flyMode = true;
            FindObjectOfType<PlayerState>().powerUp = true;
            FindObjectOfType<PlayerState>().powerUpTipe = "FlyMode";
            
        }
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Invoke("PowerUpEnd", duration);
    }
    void PowerUpEnd()
    {
        FindObjectOfType<PlayerState>().flyMode = true;
        FindObjectOfType<PlayerMovement>().flyMode = false;
        FindObjectOfType<PlayerState>().powerUp = false;
        Destroy(gameObject);
    }

}
