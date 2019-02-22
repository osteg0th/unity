using UnityEngine;

public class Cherry : MonoBehaviour {

    public GameObject efect;
	
    void OnTriggerEnter2D(Collider2D info)
    {
        if(info.name == "Player")
        {
            Destroy(Instantiate(efect, transform.position, Quaternion.identity), 1f);
            FindObjectOfType<ScoreManger>().ScoreUpdater(50);
            Destroy(gameObject);   
        }
    }
}
