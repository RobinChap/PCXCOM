using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewindScript : MonoBehaviour {
    public Vector3 startPos;
    public Vector3 startRot;
    public List<Vector3> oldPos = new List<Vector3>();
    public List<Quaternion> oldRot = new List<Quaternion>();
    
    bool rewindmode = false;
    bool start = false;
   
	// Use this for initialization
	void Start () {
    

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            
            start = true;
            rewindmode = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rewindmode = true;
        }

        if (start)
        {
            if (rewindmode)
            {
                if (oldPos.Count != 0)
                {
                    
                    this.GetComponent<Transform>().localPosition = oldPos[oldPos.Count - 1];
                    oldPos.RemoveAt(oldPos.Count - 1);
                    this.GetComponent<Transform>().rotation = oldRot[oldRot.Count - 1];
                    oldRot.RemoveAt(oldRot.Count - 1);
                }
                else
                {
                    this.GetComponent<Rigidbody>().isKinematic = true;
                    this.GetComponent<Transform>().localPosition = startPos;
                    this.GetComponent<Transform>().localEulerAngles = startRot;
                                       start = false;
                }
            }
            else
            {
                oldPos.Add(this.GetComponent<Transform>().position);
                oldRot.Add(this.GetComponent<Transform>().localRotation);
            }

        }
        else
        {
            startPos = this.GetComponent<Transform>().position;
            startRot = this.GetComponent<Transform>().eulerAngles;
        }

    }

  
    void savePos()
    {
       
    }

    IEnumerator masterCoroutine()
    {
        Debug.Log("coucou");


        yield return new WaitForEndOfFrame();
    }
}
