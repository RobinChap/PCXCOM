using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeamCreaScript : MonoBehaviour {
    public List<GameObject> Team = new List<GameObject>();
    public GameObject RessourcesDisplay, TotalCostDisplay, RemainingDisplay;
    public GameObject ErrorDisplay;
    public GameObject TextDisplay;
    public int ressources, totalCost, remaining;
    int unamed;

	// Use this for initialization
	void Start () {
        Load();
	}
	
	// Update is called once per frame
	void Update () {
        totalCost = 0;
        for(int i = 0; i < Team.Count; i++)
        {
            totalCost += Team[i].GetComponent<CharaCreaScript>().Cost;
        }
        remaining = ressources - totalCost;

        RessourcesDisplay.GetComponent<Text>().text = "Ressources : " + ressources.ToString() + " $ ";
        TotalCostDisplay.GetComponent<Text>().text = "Total Cost : " + totalCost.ToString() + " $ ";
        RemainingDisplay.GetComponent<Text>().text = "Remaining : " + remaining.ToString() + " $ ";
    }

    public void Save()
    {
        if(remaining >= 0)
        {
            unamed = 0;
            for(int i = 0; i < Team.Count; i++)
            {
                if (Team[i].GetComponent<CharaCreaScript>().nameZone.GetComponent<InputField>().text == "")
                {
                    unamed++;
                }
            }
            if(unamed == 0)
            {
                ErrorDisplay.GetComponent<Text>().text = "Ok Je sauvegarde ça";
                for(int i = 0; i < Team.Count; i++)
                {
                    PlayerPrefs.SetString("Chara" + i.ToString() + "Name", Team[i].GetComponent<CharaCreaScript>().nameZone.GetComponent<InputField>().text);
                    PlayerPrefs.SetString("Chara" + i.ToString() + "Classe", Team[i].GetComponent<CharaCreaScript>().Classe);
                    PlayerPrefs.SetInt("Chara" + i.ToString() + "Dammage", Team[i].GetComponent<CharaCreaScript>().Dammage);
                    PlayerPrefs.SetInt("Chara" + i.ToString() + "FireRate", Team[i].GetComponent<CharaCreaScript>().FireRate);
                    PlayerPrefs.SetInt("Chara" + i.ToString() + "Shield", Team[i].GetComponent<CharaCreaScript>().Shield);
                    PlayerPrefs.SetInt("Chara" + i.ToString() + "Cost", Team[i].GetComponent<CharaCreaScript>().Cost);
                }
                TextDisplay.SetActive(true);
                TextDisplay.GetComponent<nextScript>().nexttxt();
            }
            else
            {
                ErrorDisplay.GetComponent<Text>().text = "Loic arrête d'être un flemmard et nomme tes persos !";
            }
        }
        else
        {
            ErrorDisplay.GetComponent<Text>().text = "Error : Cost too hight !";
        }
    }

    void Load()
    {
        for(int i = 0; i < Team.Count; i++)
        {
            Team[i].GetComponent<CharaCreaScript>().nameZone.GetComponent<InputField>().text = PlayerPrefs.GetString("Chara" + i.ToString() + "Name");
            Team[i].GetComponent<CharaCreaScript>().changeClass(PlayerPrefs.GetString("Chara" + i.ToString() + "Classe"));
            Team[i].GetComponent<CharaCreaScript>().Dammage = PlayerPrefs.GetInt("Chara" + i.ToString() + "Dammage");
            Team[i].GetComponent<CharaCreaScript>().FireRate = PlayerPrefs.GetInt("Chara" + i.ToString() + "FireRate");
            Team[i].GetComponent<CharaCreaScript>().Shield = PlayerPrefs.GetInt("Chara" + i.ToString() + "Shield");

            if(PlayerPrefs.GetString("Chara" + i.ToString() + "Classe") == "Soldier")
            {
                Team[i].GetComponent<CharaCreaScript>().SoldierToogled();
            }
            if (PlayerPrefs.GetString("Chara" + i.ToString() + "Classe") == "Sniper")
            {
                Team[i].GetComponent<CharaCreaScript>().SniperToogled();
            }
            if (PlayerPrefs.GetString("Chara" + i.ToString() + "Classe") == "Tank")
            {
                Team[i].GetComponent<CharaCreaScript>().TankToogled();
            }
            if (PlayerPrefs.GetString("Chara" + i.ToString() + "Classe") == "Medic")
            {
                Team[i].GetComponent<CharaCreaScript>().MedicToogled();
            }
        }

       
    }
}
