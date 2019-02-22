using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    int shootMode = 1;
    int damage = 20;
    bool shoot = false;
    public GameObject bullet;
    public Transform shootingPoint;
    public GameObject efect;
    public LineRenderer line;

	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot = true;
        }
        if (Input.GetKey("1"))
            shootMode = 1;
        if (Input.GetKey("2"))
            shootMode = 2;
    }
    void FixedUpdate()
    {
        if (shoot)
        {
            if (shootMode == 1)
                PrefabShoot();
            else if (shootMode == 2)
                RaycastShoot();                
            //StartCoroutine(RaycastShoot());
        }
    }
    void PrefabShoot()
    {
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        shoot = false;
    }
    void RaycastShoot()
    {
        line.enabled = true;
        RaycastHit2D hitInfo = Physics2D.Raycast(shootingPoint.position, shootingPoint.right, 5f);
        if (hitInfo.transform != null)
        {
            if (hitInfo.transform.tag == "Enemy")
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(damage);
                }
                Destroy(Instantiate(efect, hitInfo.transform.position, Quaternion.identity), 0.5f);
            }
            line.SetPosition(0, shootingPoint.position);
            line.SetPosition(1, hitInfo.point);
        }
        else
        {
            line.SetPosition(0, shootingPoint.position);
            line.SetPosition(1, shootingPoint.position + shootingPoint.right * 5);
        }
        Invoke("LineOff", 0.05f);
        shoot = false;
    }
    void LineOff()
    {
        line.enabled = false;
    }
    //IEnumerator   RaycastShoot()
    //{
    //    line.enabled = true;
    //    RaycastHit2D hitInfo = Physics2D.Raycast(shootingPoint.position, shootingPoint.right);
    //    if (hitInfo.transform != null)
    //    {
    //        if (hitInfo.transform.name == "Enemy")
    //        {
    //            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
    //            if (enemy != null)
    //            {
    //                enemy.GetComponent<Enemy>().TakeDamage(damage);
    //            }
    //            Destroy(Instantiate(efect, hitInfo.transform.position, Quaternion.identity), 0.5f);
    //        }
    //        line.SetPosition(0, shootingPoint.position);
    //        line.SetPosition(1, hitInfo.point);
    //    }
    //    else
    //    {
    //        line.SetPosition(0, shootingPoint.position);
    //        line.SetPosition(1, shootingPoint.position + shootingPoint.right * 100);
    //    }

    //    yield return 0.02;
    //    line.enabled = false;
    //    shoot = false;
    //}

}
