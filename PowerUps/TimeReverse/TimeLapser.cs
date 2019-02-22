using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLapser : MonoBehaviour {
  
    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();
    List<float> hp = new List<float>();
    public bool savingPositions = true;
    public bool startRewind = false;
    public bool rewindMode;
    bool rewindIsAllowed = true;
    //bool rewindIsAllowed = true;
    

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<TimeReverser>()!=null)
        rewindMode = FindObjectOfType<TimeReverser>().modOn;
        if (Input.GetKeyDown(KeyCode.Return))
            StartRevinding();
        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();
    }
    void FixedUpdate ()
    {
        if (rewindMode)
        {
            if (startRewind)
                Rewind();
            else Record();
        }
    }
    void Record()
    {
        hp.Insert(0, FindObjectOfType<PlayerState>().hp);
        rotations.Insert(0, transform.rotation);
        positions.Insert(0, transform.position);
    }
    void Rewind()
    {
        if (positions.Count != 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        if (rotations.Count != 0)
        {
            transform.rotation = rotations[0];
            rotations.RemoveAt(0);
        }
        if (hp.Count != 0)
        {
            FindObjectOfType<PlayerState>().hp = hp[0];
            hp.RemoveAt(0);
        }
    }
    void StartRevinding()
    {
        startRewind = true;
        
    }
    void StopRewind()
    {
        startRewind = false;
    }
}
