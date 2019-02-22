using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReverser : MonoBehaviour {

    public bool modOn=false;
    bool startReverse = false;
    public GameObject efect;
    public float duration;
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Return) & modOn)
        {
            duration += Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.Return))
        {
            modOneverseOf();
        }
    }
	void OnTriggerEnter(Collider info)
    {
        if(info.name == "Player")
        {
            modOneverseOn();
        }
    }
    void modOneverseOn()
    {
        if (FindObjectOfType<PlayerState>().timeRewerse)
        {
            duration *= 2;

        }
        else
        {
            FindObjectOfType<PlayerState>().powerUp = true;
            FindObjectOfType<PlayerState>().powerUpTipe = "TimeRewerse";
            FindObjectOfType<PlayerState>().timeRewerse = true;
            modOn = true;
        }
        Destroy(Instantiate(efect, transform.position, Quaternion.identity), 1f);
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Invoke("modOneverseOf", duration);
       
    }
    void modOneverseOf()
    {
        modOn = false;
        FindObjectOfType<PlayerState>().powerUp = false;
        FindObjectOfType<PlayerState>().timeRewerse = false;
        Destroy(gameObject,1f);

    }
}
