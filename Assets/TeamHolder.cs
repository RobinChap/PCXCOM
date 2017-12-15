using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHolder : MonoBehaviour {
    public List<GameObject> Team = new List<GameObject>();
    public GameObject currentRoom;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeRoom(GameObject nextRoom)
    {
        currentRoom.GetComponent<RoomScript>().currentRoom = false;
        nextRoom.GetComponent<RoomScript>().currentRoom = true;
        currentRoom = nextRoom;
    }
}
