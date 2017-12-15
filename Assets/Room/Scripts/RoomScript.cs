using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {
    public bool currentRoom = false;
    bool isGenerated = false;
    public bool roomLeft, roomRight, roomFront, roomBack;
    public GameObject casePrefab, wallPrefab, roofPrefab, cameraPrefab, lightPrefab, doorPrefab;
    public GameObject RoomCamera;
    public GameObject Text;
    public int floorX, floorY;
     GameObject[,] caseTab = new GameObject[20, 20];
     GameObject[] wall = new GameObject[4];
     GameObject[] door = new GameObject[4];
    GameObject roof, roomlight;
    public int compteur;
    public int difficulty;

    public int nbEnnemy, nbAlly, nbNPC;
    public int nbCover;
    public int ordreAlly, ordreEnnemy;


    // Use this for initialization
    void Start () {
        // this.gameObject.GetComponent<Transform>().localScale = new Vector3(floorX,0.1f,floorY);
        GenerateRoom();

        ordreAlly = 0;
        ordreEnnemy = 0;

        switch (difficulty)
        {
            case 0:
                nbEnnemy = 0;
                nbCover = 0;
                nbAlly = 0;
                nbNPC = 1;
                break;
            case 1:
                nbEnnemy = 5;
                nbCover = 10;
                nbAlly = 5;
                break;
            case 2:
                nbEnnemy = 8;
                nbCover = 15;
                nbAlly = 5;
                break;
            case 3:
                nbEnnemy = 10;
                nbCover = 10;
                nbAlly = 5;
                break;
            default:
                nbEnnemy = 0;
                nbCover = 0;
                nbAlly = 0;
                break;
        }
        }

    void GenerateRoom()
    {
       for(int i = 0; i < floorX; i++)
        {
            for(int j = 0; j < floorY; j++)
            {
                spawnCase(i, j);
            }
        }
       for(int i = 0; i < 4; i++)
        {
            spawnWall(i);
        }
        setupWall();
        spawnRoof();
        spawnCamera();
        spawnLight();
    }

    void spawnCase(int i, int j)
    {
        caseTab[i, j] = Instantiate(casePrefab, new Vector3(0, 0, 0), new Quaternion());
        caseTab[i, j].GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        caseTab[i, j].GetComponent<Transform>().localPosition = new Vector3(i - floorX / 2, 0, j - floorY / 2);
        
        caseTab[i, j].GetComponent<apparitionScript>().value = Random.Range(5, 40);
        caseTab[i, j].GetComponent<ItemGeneratorScript>().prefab = null;

    }

    void spawnWall(int i)
    {
        wall[i] = Instantiate(wallPrefab, new Vector3(0, 0, 0), new Quaternion());
        wall[i].GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        wall[i].GetComponent<Transform>().localScale = new Vector3(floorX, 100, 0.1f);
        
        wall[i].GetComponent<apparitionScript>().value = Random.Range(40, 50); ;
    }

    void setupWall()
    {
        wall[0].GetComponent<Transform>().localPosition = new Vector3(-floorX / 2 , 50, 0); // left
        wall[0].GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);
        wall[1].GetComponent<Transform>().localPosition = new Vector3(0, 50, -floorY/ 2 + 0.5f); // up
        wall[1].GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        wall[2].GetComponent<Transform>().localPosition = new Vector3(0, 50, +floorY / 2 - 0.5f); // down
        wall[2].GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        wall[3].GetComponent<Transform>().localPosition = new Vector3(+floorX / 2 , 50, 0); // right
        wall[3].GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);

        if (roomFront)
        {
            door[0] = Instantiate(doorPrefab, new Vector3(0,0,0), new Quaternion());
            door[0].GetComponent<Transform>().SetParent(wall[0].transform);
            door[0].GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);

        }
        if (roomBack)
        {
            door[1] = Instantiate(doorPrefab, new Vector3(0, 0, 0), new Quaternion());
            door[1].GetComponent<Transform>().SetParent(wall[1].transform);
            door[1].GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);

        }
        if (roomLeft)
        {
            door[2] = Instantiate(doorPrefab, new Vector3(0, 0, 0), new Quaternion());
            door[2].GetComponent<Transform>().SetParent(wall[2].transform);
            door[2].GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);

        }
        if (roomFront)
        {
            door[3] = Instantiate(doorPrefab, new Vector3(0, 0, 0), new Quaternion());
            door[3].GetComponent<Transform>().SetParent(wall[3].transform);
            door[3].GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);

        }


    }

    void spawnRoof()
    {
        roof = Instantiate(roofPrefab, new Vector3(0, 0, 0), new Quaternion());
        roof.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        roof.GetComponent<Transform>().localPosition = new Vector3(0, 100, 0);
        roof.GetComponent<Transform>().localScale = new Vector3(floorX, 0.1f, floorY);
       
        roof.GetComponent<apparitionScript>().value = Random.Range(45, 50); ;
    }

    void spawnCamera()
    {
        RoomCamera = Instantiate(cameraPrefab, new Vector3(0, 0, 0), new Quaternion());
        RoomCamera.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        RoomCamera.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
    }

    void spawnLight()
    {
        roomlight = Instantiate(lightPrefab, new Vector3(0, 0, 0), new Quaternion());
        roomlight.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        roomlight.GetComponent<Transform>().localPosition = new Vector3(0, 90, 0);
    }



    // Update is called once per frame
    void Update () {

        if(currentRoom == true)
        {
            RoomCamera.SetActive(true);
            roomlight.SetActive(true);
            generateItems();
            if(Text != null)
            {
                Text.SetActive(true);
                Text = null;
            }

        }
        else
        {
            roomlight.SetActive(false);
            RoomCamera.SetActive(false);
        }
        
    }

    void generateItems()
    {
        if (isGenerated == false)
        {
            Debug.Log("Doing stuff");
            isGenerated = true;
            for (int i = 0; i < nbAlly; i++)
            {
                int x = Random.Range(0, floorX - 1);
                int y = Random.Range(0, floorY - 1);

                if (caseTab[x, y].GetComponent<ItemGeneratorScript>().prefab == null)
                {
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().prefab = Camera.main.GetComponent<PrefabHolderItemScript>().allySpawn;
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().initItems();
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().Item.GetComponent<spawnerScript>().ordre = ordreAlly;
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().Item.GetComponent<spawnerScript>().player = true;
                    ordreAlly++;

                }
                else
                {
                    nbAlly++;
                }

            }

            for (int i = 0; i < nbEnnemy; i++)
            {
                int x = Random.Range(0, floorX - 1);
                int y = Random.Range(0, floorY - 1);

                if (caseTab[x, y].GetComponent<ItemGeneratorScript>().prefab == null)
                {
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().prefab = Camera.main.GetComponent<PrefabHolderItemScript>().ennemySpawn;
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().initItems();
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().Item.GetComponent<spawnerScript>().ordre = ordreEnnemy;
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().Item.GetComponent<spawnerScript>().ennemy = true;
                    ordreEnnemy++;
                }
                else
                {
                    nbEnnemy++;
                }

            }

            for (int i = 0; i < nbCover; i++)
            {
                int x = Random.Range(0, floorX - 1);
                int y = Random.Range(0, floorY - 1);

                if (caseTab[x, y].GetComponent<ItemGeneratorScript>().prefab == null)
                {
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().prefab = Camera.main.GetComponent<PrefabHolderItemScript>().cover;
                    caseTab[x, y].GetComponent<ItemGeneratorScript>().initItems();
                }
                else
                {
                    nbCover++;
                }

            }

            if(nbNPC > 0)
            {
                caseTab[10, 10].GetComponent<ItemGeneratorScript>().prefab = Camera.main.GetComponent<PrefabHolderItemScript>().NPCSpawn;
                caseTab[10, 10].GetComponent<ItemGeneratorScript>().initItems();
            }
        }
    }
}
