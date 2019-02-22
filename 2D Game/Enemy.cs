
using UnityEngine;

public class Enemy : MonoBehaviour {
    bool takeDamage = false;
    int hp = 100;
    bool moveLeft = true;
    bool facingLeft = true;
    public float speed = 100f;
    float speedTemp;
    public float zone = 10f;
    Vector2 originalPosition = new Vector2();
    Rigidbody2D rb;
    public GameObject deathEfect;
    Animator animator;
    void Start()
    {
        speedTemp = speed;
        rb = GetComponent < Rigidbody2D>();
        originalPosition = transform.position;
        animator = GetComponent<Animator>();
    }
	void Update ()
    {
        if (hp <= 0)
            IsDead();
        if (transform.position.x < originalPosition.x - zone&&facingLeft)
        {
            Flip();
        }
        else if (transform.position.x > originalPosition.x + zone&&!facingLeft)
        {
            Flip();
        }
       

    }
    void FixedUpdate()
    {
        rb.velocity = -transform.right * speed * Time.deltaTime;
    }
    
    private void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0, 180f, 0);
    }
    void IsDead()
    {
        Destroy(Instantiate(deathEfect, transform.position, Quaternion.identity), 1f);
        Destroy(gameObject);
        FindObjectOfType<ScoreManger>().ScoreUpdater(100);
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        animator.SetBool("IsDamaged", true);
        speed = 0; 
        Invoke("AnimationOff", 0.5f);
    }
    void AnimationOff()
    {
        animator.SetBool("IsDamaged", false);
        speed = speedTemp;
    }
   
}
