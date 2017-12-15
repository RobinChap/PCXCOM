using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomScript : MonoBehaviour {
    public List<GameObject> target = new List<GameObject>();
    public Vector3 bombpos, blocpos;

    public float force = 2000;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            bombpos = this.GetComponent<Transform>().position;
            boombb();
        }

    }

    void boombb()
    {
        foreach(GameObject block in GameObject.FindGameObjectsWithTag("boom"))
        {
            if (true)
            {
                blocpos = block.GetComponent<Transform>().position;
                Debug.Log("boom" + block.name);
                block.GetComponent<Rigidbody>().AddExplosionForce(force, bombpos, 200);
            }
        }

    } 
}
