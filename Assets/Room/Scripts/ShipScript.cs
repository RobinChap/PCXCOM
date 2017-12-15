using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour {
    public GameObject StartPrefab, EndPrefab, RoomPrefab;
    public List<int> RowPrefab1 = new List<int>();
    public List<int> RowPrefab2 = new List<int>();
    public List<int> RowPrefab3 = new List<int>();

    public List<GameObject> Row1 = new List<GameObject>();
    public List<GameObject> Row2 = new List<GameObject>();
    public List<GameObject> Row3 = new List<GameObject>();

    public GameObject startTxt;

    GameObject room;
    
    // Use this for initialization
    void Start () {
        
        for(int i = 0; i < RowPrefab1.Count; i++)
        {

            if (RowPrefab1[i] == 1)
            {
                room = Instantiate(StartPrefab, new Vector3(0, 0, 0), new Quaternion());
                Camera.main.GetComponent<apparitioncamScript>().start = room;
                room.GetComponent<RoomScript>().difficulty = 0;
                room.GetComponent<RoomScript>().Text = startTxt;

            }
            if (RowPrefab1[i] == 2)
            {
                room = Instantiate(RoomPrefab, new Vector3(0, 0, 0), new Quaternion());
                room.GetComponent<RoomScript>().difficulty = Random.Range(1, 3);
            }
            if (RowPrefab1[i] == 3)
            {
                room = Instantiate(EndPrefab, new Vector3(0, 0, 0), new Quaternion());
                room.GetComponent<RoomScript>().difficulty = 0;
            }
            if (RowPrefab1[i] != 0)
            {
                Row1.Add(room);
                room.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
                room.GetComponent<Transform>().localPosition = new Vector3(0, 0, 21 * i);
            }

            /*if (RowPrefab2[i] != 0)
            {
                room.GetComponent<RoomScript>().roomRight = true;
            }
            if (i != RowPrefab1.Count -1 && RowPrefab1[i + 1] != 0)
            {
                room.GetComponent<RoomScript>().roomBack = true;
            }
            if (i != 0 && RowPrefab1[i -1] != 0)
            {
                room.GetComponent<RoomScript>().roomFront = true;
            }*/

        }

        for (int i = 0; i < RowPrefab2.Count; i++)
        {
           
            if (RowPrefab2[i] == 1)
            {
                room = Instantiate(StartPrefab, new Vector3(0, 0, 0), new Quaternion());
                Camera.main.GetComponent<apparitioncamScript>().start = room;
                room.GetComponent<RoomScript>().Text = startTxt;
            }
            if (RowPrefab2[i] == 2)
            {
                room = Instantiate(RoomPrefab, new Vector3(0, 0, 0), new Quaternion());
                room.GetComponent<RoomScript>().difficulty = Random.Range(1, 3);
            }
            if (RowPrefab2[i] == 3)
            {
                room = Instantiate(EndPrefab, new Vector3(0, 0, 0), new Quaternion());

            }

            if(RowPrefab2[i] != 0)
            {
                Row2.Add(room);
                room.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
                room.GetComponent<Transform>().localPosition = new Vector3(21, 0, 21 * i);
            }

          /*  if (RowPrefab1[i] != 0)
            {
                room.GetComponent<RoomScript>().roomLeft = true;
            }
            if (RowPrefab3[i] != 0)
            {
                room.GetComponent<RoomScript>().roomRight = true;
            }
            if (i != RowPrefab3.Count -1 && RowPrefab3[i + 1] != 0)
            {
                room.GetComponent<RoomScript>().roomBack = true;
            }
            if (i != 0 && RowPrefab3[i - 1] != 0)
            {
                room.GetComponent<RoomScript>().roomFront = true;
            }*/


        }

        for (int i = 0; i < RowPrefab3.Count; i++)
        {
           

            if (RowPrefab3[i] == 1)
            {
                room = Instantiate(StartPrefab, new Vector3(0, 0, 0), new Quaternion());
                Camera.main.GetComponent<apparitioncamScript>().start = room;
                room.GetComponent<RoomScript>().difficulty = 0;
                room.GetComponent<RoomScript>().Text = startTxt;
            }
            if (RowPrefab3[i] == 2)
            {
                room = Instantiate(RoomPrefab, new Vector3(0, 0, 0), new Quaternion());
                room.GetComponent<RoomScript>().difficulty = Random.Range(1, 3);
            }
            if (RowPrefab3[i] == 3)
            {
                room = Instantiate(EndPrefab, new Vector3(0, 0, 0), new Quaternion());
                room.GetComponent<RoomScript>().difficulty = 0;
            }

            if (RowPrefab3[i] != 0)
            {
                Row3.Add(room);
                room.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
                room.GetComponent<Transform>().localPosition = new Vector3(42, 0, 21 * i);
            }
            /*
            if (RowPrefab2[i] != 0)
            {
                room.GetComponent<RoomScript>().roomLeft = true;
            }
            if (i != RowPrefab3.Count -1 && RowPrefab3[i + 1] != 0)
            {
                room.GetComponent<RoomScript>().roomBack = true;
            }
            if (i != 0 && RowPrefab3[i - 1] != 0)
            {
                room.GetComponent<RoomScript>().roomFront = true;
            }*/

        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
