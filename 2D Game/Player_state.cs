using UnityEngine;
using UnityEngine.UI;

public class Player_state : MonoBehaviour {

    public Slider hpSlide;
    bool takeDamage = false;
    Animator animator;
    [HideInInspector]
    public float hp = 100;
    public GameObject deathEfect;
    [HideInInspector]
    public Vector3  position;

    // Use this for initialization
	void Start ()
    {
        
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();
        Debug.Log(PlayerPrefs.GetInt("Score", 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
        position = GetComponent<Transform>().position;
        hpSlide.value = hp;
        if (hp <= 0)
            Invoke("IsDead", 0.5f);
	}
    void OnCollisionEnter2D(Collision2D info)
    {
        if (info.collider.tag== "Enemy"&& !takeDamage)
        {
            hp -= 20;
            animator.SetBool("Damaged", true);
            Invoke("EndAnimation", 0.5f);
            takeDamage = true;
        }
    }
    void EndAnimation()
    {
        animator.SetBool("Damaged", false);
        takeDamage = false;
    }
    void IsDead()
    {
        Destroy(Instantiate(deathEfect, transform.position, Quaternion.identity), 1f);
        FindObjectOfType<Quit>().StartAgain();
        Destroy(gameObject);
    }
    

}
