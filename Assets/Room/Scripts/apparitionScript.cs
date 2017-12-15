using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apparitionScript : MonoBehaviour {
    public float value = 0;
	// Use this for initialization
	void Start () {
        this.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.GetComponent<apparitioncamScript>().value == value)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
		
	}
}
