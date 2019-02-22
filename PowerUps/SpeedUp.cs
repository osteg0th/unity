using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public float duration;
    GameObject player;
    public GameObject powerUpEfect;

    void OnTriggerEnter(Collider info)
    {
        if(info.name =="Player")
        {
            PowerUp();
            player = info.gameObject;
        }
    }
    void PowerUp()
    {
        if(FindObjectOfType<PlayerState>().speedUp)
        {
            duration *= 2;
        }
        else
        {
            FindObjectOfType<PlayerState>().speedUp = true;
            FindObjectOfType<PlayerMovement>().speed *= 2;
            FindObjectOfType<PlayerState>().powerUp = true;
            FindObjectOfType<PlayerState>().powerUpTipe = "SpeedUp";
        }
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(Instantiate(powerUpEfect, transform.position, transform.rotation), 1f);
        Invoke("PowerOff", duration);
        
    }
    void PowerOff()
    {
        FindObjectOfType<PlayerState>().speedUp = false;
        FindObjectOfType<PlayerMovement>().speed /= 2;
        FindObjectOfType<PlayerState>().powerUp = false;
        Destroy(gameObject);

    }
}
