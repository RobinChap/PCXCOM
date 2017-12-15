using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorScript : MonoBehaviour {
    public GameObject prefab;
    public GameObject Item;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void initItems()
    {
                Item = Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion());
                Item.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
                Item.GetComponent<Transform>().localPosition = new Vector3(0, 1, 0);
    }
    }
