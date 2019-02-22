using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    

   
    public int amount = 10;
    public float spawnInterval = 10f;
    public GameObject[] obstcl;
    public float minZ = 20f;
    public float maxZ = 30f;
    float spawnTime = 5f;
    Vector3 position = new Vector3();
   

    void Start()
    {
        position.y = 0.5f;
        position.x = 0;
        Spawner();
    }
    void FixedUpdate()
    {
        if(Time.time>spawnTime)
        {
            Spawner();
            spawnTime += spawnInterval;
        }
        
    }
    void Spawner()
    {
        for (int i = 0; i < amount; i++)
        {
            position.z += Random.Range(minZ, maxZ);
            Instantiate(obstcl[Random.Range(0, obstcl.Length)], position, Quaternion.identity);
            
        }
    }
    
    
}
