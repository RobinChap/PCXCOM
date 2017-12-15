using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrolScript : MonoBehaviour {

    public float speed;
    public float xmouse, ymouse;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void FixedUpdate() {

        xmouse = Input.GetAxis("Mouse Y");
        ymouse = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.Z))
        {
            this.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<Rigidbody>().AddForce(transform.forward * -10);
        }
        this.GetComponent<Transform>().localEulerAngles += new Vector3(xmouse, -ymouse, 0);
        
    }
}
