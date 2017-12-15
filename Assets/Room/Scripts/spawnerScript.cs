using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour {
   public GameObject spawnedPrefab;
   public GameObject spawned;
    public bool player, ennemy;
    public int ordre;

	// Use this for initialization
	void Start () {
        if (player)
        {
            if (PlayerPrefs.GetString("Chara" + ordre.ToString() + "Classe") == "Sniper")
            {
                spawnedPrefab = Camera.main.GetComponent<PrefabHolderCharaScript>().SniperPrefab;
            }
            if (PlayerPrefs.GetString("Chara" + ordre.ToString() + "Classe") == "Soldier")
            {
                spawnedPrefab = Camera.main.GetComponent<PrefabHolderCharaScript>().SoldierPrefab;
            }
            if (PlayerPrefs.GetString("Chara" + ordre.ToString() + "Classe") == "Tank")
            {
                spawnedPrefab = Camera.main.GetComponent<PrefabHolderCharaScript>().TankPrefab;
            }
            if (PlayerPrefs.GetString("Chara" + ordre.ToString() + "Classe") == "Medic")
            {
                spawnedPrefab = Camera.main.GetComponent<PrefabHolderCharaScript>().MedicPrefab;
            }
        }

        spawned = Instantiate(spawnedPrefab, new Vector3(0, 0, 0), new Quaternion());
        spawned.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        spawned.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        spawned.GetComponent<Transform>().localScale = new Vector3(5, 5, 5);
        spawned.GetComponent<Transform>().localEulerAngles = new Vector3(0, 180, 0);

        if (player)
        {
            spawned.GetComponent<SoldierScript>().Dammage = PlayerPrefs.GetInt("Chara"+ ordre.ToString() + "Dammage");
            spawned.GetComponent<SoldierScript>().FireRate = PlayerPrefs.GetInt("Chara"+ ordre.ToString() + "FireRate");
            spawned.GetComponent<SoldierScript>().Shield = PlayerPrefs.GetInt("Chara"+ ordre.ToString() + "Shield");
            spawned.GetComponent<SoldierScript>().Name = PlayerPrefs.GetString("Chara"+ ordre.ToString() + "Name");
            
            Camera.main.GetComponent<TeamHolder>().Team.Add(spawned);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
