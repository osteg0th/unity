using UnityEngine;

public class TankUp : MonoBehaviour {

    public float duration = 2f;
    GameObject player;
    GameObject temp;
    public GameObject powerUpEffect;
  
    void OnTriggerEnter(Collider info)
    {

        if(info.name == "Player")
        { 
            player = info.gameObject;
            TankUpOn();
        }
    }
    void TankUpOn()
    {
        if (FindObjectOfType<PlayerState>().tankUp)
        {
            duration *= 2;
   
        }
        else
        {
            FindObjectOfType<PlayerState>().tankUp = true;
            FindObjectOfType<PlayerState>().powerUp = true;
            FindObjectOfType<PlayerState>().powerUpTipe = "TankUp";
            player.GetComponent<Rigidbody>().mass = 200;
            player.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
           player.GetComponent<Transform>().Rotate(0, 45, 0);
            FindObjectOfType<PlayerState>().invinsible = true;
            player.GetComponent<Rigidbody>().freezeRotation = true;
            
        }
        temp = Instantiate(powerUpEffect, transform.position, transform.rotation);
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Invoke("TankUpOff", duration);

    }
    void TankUpOff()
    {
        FindObjectOfType<PlayerState>().tankUp = false;
        FindObjectOfType<PlayerState>().powerUp = false;
        player.GetComponent<Rigidbody>().mass = 1;
        player.GetComponent<Transform>().Rotate(0, 45, 0);
        FindObjectOfType<PlayerState>().invinsible = false;
        player.GetComponent<Rigidbody>().freezeRotation = false;
        Destroy(gameObject);
        Destroy(temp); 
    }

}
