using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShoot : MonoBehaviour {

    public float hitPower = 1f;
    public float distansce = 100f;
    RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }
    void Shoot()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, distansce))
        {
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            if (rb != null && !rb.isKinematic && rb.constraints == RigidbodyConstraints.None)
            {
                Vector3 direction = (hit.point - transform.position).normalized;
                rb.AddForceAtPosition(direction * hitPower, hit.point);
            }
            Debug.Log("Got hit into object: " + hit.transform.name);
        }
        else
            Debug.Log("You missed");
    }
}
