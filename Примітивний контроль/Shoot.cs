using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float power = 10f;
    public GameObject bulletPref;
    public Transform muzzle;

    GameObject bullet;
	
	
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            Shot();
	}
    void Shot()
    {
        bullet = Instantiate(bulletPref, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * power, ForceMode.Impulse);
        Destroy(bullet, 2f);
    }
}
