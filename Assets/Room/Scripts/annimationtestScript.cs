using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class annimationtestScript : MonoBehaviour {
    public Animation anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        foreach(AnimationState state in anim)
        {
           
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
