using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apparitioncamScript : MonoBehaviour {
    public float value;
    public float time = 0;
    public GameObject start;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time <= 1)
        {
            value++;
            time = 0;
        }
        if (value >= 50)
        {
            start.GetComponent<RoomScript>().currentRoom = true;
            this.GetComponent<TeamHolder>().currentRoom = start;
            
        }
        if(value >= 100)
        {
            this.GetComponent<apparitioncamScript>().enabled = false;
        }
	}
}
