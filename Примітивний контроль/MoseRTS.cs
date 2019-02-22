using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoseRTS : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public Vector3 offset = new Vector3 (0, 1, 0);
    public float radius = 2;
    bool moveComplete = true;
    public float speed = 1;
    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            MouseClick();
        }
    }
    private void MouseClick()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag=="Ground")
            {
                Move(hit.point);
            }
        }
    }
    private void Move(Vector3  _point)
    {
        if(!moveComplete)
        {
            StopCoroutine("Move_Proc"); 
        }
        StartCoroutine("Move_Proc", _point); 
    }
    private IEnumerator Move_Proc(Vector3 _point)
    {
        moveComplete = false;

        transform.LookAt(_point + offset);
        while(!moveComplete)
        {
            transform.position = transform.position + transform.forward * speed;
            if (Vector3.Distance(transform.position, _point + offset) < radius)
                moveComplete = true;  
        yield return null;
        }
        yield break;
    }
	
}
