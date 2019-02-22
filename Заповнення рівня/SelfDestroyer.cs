using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour {

	
	void Update ()
    {
        if(!FindObjectOfType<TimeLapser>().rewindMode)
        if (transform.position.z < FindObjectOfType<PlayerState>().player.position.z)
            Destroy(gameObject, 3f);
        if (FindObjectOfType<PlayerState>().isDead)
            Destroy(gameObject);
	}
}
