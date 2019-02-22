using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMode : MonoBehaviour {

    public float duration;
    public GameObject efect;
    GameObject player;
    void OnTriggerEnter(Collider info)
    {
        if(info.name == "Player")
        {
            player = info.gameObject;
            BombModeOn();
        }
    }
    void BombModeOn()
    {
        if(FindObjectOfType<PlayerState>().bombMode == true)
        {
            duration *= 2;
        }
        else
        {
            FindObjectOfType<PlayerState>().bombMode = true;
            FindObjectOfType<PlayerState>().powerUpTipe = "BombMode";
            FindObjectOfType<PlayerState>().powerUp = true;
        }
        Destroy(Instantiate(efect, transform.position, transform.rotation), 1f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Invoke("BombModeOff", duration);
    }
    void BombModeOff()
    {
        FindObjectOfType<PlayerState>().powerUp = false;
        FindObjectOfType<PlayerState>().bombMode = false;
        Destroy(gameObject);
    }
}
