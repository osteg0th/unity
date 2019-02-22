using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed=20;
    Rigidbody2D rb;
    public GameObject efect;
    public int damage = 20;
    public float bulletForce = 2;
    Vector2 force = new Vector2(); 
	// Use this for initialization
	void Start ()
    {
        force.x = bulletForce;
        force.y = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter2D(Collider2D info)
    {
        if (info.tag == "Enemy") 
        {
            Destroy(Instantiate(efect, transform.position, Quaternion.identity), 1f);
            Enemy enemy = info.GetComponent<Enemy>();
            if(enemy!=null)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
                info.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse); 
            }
            Destroy(gameObject);
        }     
    }
	
}
