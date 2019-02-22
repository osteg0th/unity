using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalLife : MonoBehaviour {

    public GameObject powerUpEfect;
	void OnTriggerEnter(Collider info)
    {
        if(info.name == "Player")
        {
            GiveAdittionalLife();
        }
    }
    void GiveAdittionalLife()
    {
        Destroy(Instantiate(powerUpEfect, transform.position, transform.rotation),1f);
        FindObjectOfType<PlayerState>().hp += 1;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 1.1f);
    }
}
