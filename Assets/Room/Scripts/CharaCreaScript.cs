using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaCreaScript : MonoBehaviour {
    public GameObject nameZone;
    public GameObject SoldierToogle, SniperToogle, TankToogle, MedicToogle;
    public GameObject DammageDisplay, FireRateDisplay, ShieldDisplay, CostDisplay;
    public int Dammage, FireRate, Shield, Cost;
    public string Classe;
   

	// Use this for initialization
	void Start () {
        SoldierToogled();
        DamageUp();
        FireRateUp();
        ShieldUp();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCost();	
	}
    
    public void UpdateCost()
    {
        Cost = Dammage * 10 + Shield * 30 + FireRate * 10;
        CostDisplay.GetComponent<Text>().text = Cost.ToString();
    }

    public void DamageUp()
    {
        Dammage ++;
        DammageDisplay.GetComponent<Text>().text = Dammage.ToString();
        
    }

    public void DamageDown()
    {
        if (Dammage > 1)
        {
            Dammage--;
        }
        DammageDisplay.GetComponent<Text>().text = Dammage.ToString();
    }
    public void FireRateUp()
    {
        FireRate++;
        FireRateDisplay.GetComponent<Text>().text = FireRate.ToString();
    }

    public void FireRateDown()
    {
        if (FireRate > 1)
        {
            FireRate--;
        }
        FireRateDisplay.GetComponent<Text>().text = FireRate.ToString();
    }
    public void ShieldUp()
    {
        Shield++;
        ShieldDisplay.GetComponent<Text>().text = Shield.ToString();
    }

    public void ShieldDown()
    {
        if (Shield > 1)
        {
            Shield--;
        }
        ShieldDisplay.GetComponent<Text>().text = Shield.ToString();
    }

    public void changeClass(string Classe)
    {
        if (Classe == "Sniper")
        {
            SniperToogled();
        }
        else if(Classe == "Soldier")
        {
            SoldierToogled();
        }
        else if(Classe == "Tank")
        {
            TankToogled();
        }
        else if (Classe == "Medic")
        {
            MedicToogled();
        }
    }

    public void SniperToogled()
    {
        if (SniperToogle.GetComponent<Toggle>().isOn)
        {
            SoldierToogle.GetComponent<Toggle>().isOn = false;
            TankToogle.GetComponent<Toggle>().isOn = false;
            MedicToogle.GetComponent<Toggle>().isOn = false;
            SniperToogle.GetComponent<Toggle>().isOn = true;

            SniperToogle.GetComponent<Toggle>().enabled = false;
            MedicToogle.GetComponent<Toggle>().enabled = true;
            TankToogle.GetComponent<Toggle>().enabled = true;
            SoldierToogle.GetComponent<Toggle>().enabled = true;

            Classe = "Sniper";

        }

    }

    public void SoldierToogled()
    {
        if (SoldierToogle.GetComponent<Toggle>().isOn)
        {
            SoldierToogle.GetComponent<Toggle>().isOn = true;
            TankToogle.GetComponent<Toggle>().isOn = false;
            MedicToogle.GetComponent<Toggle>().isOn = false;
            SniperToogle.GetComponent<Toggle>().isOn = false;

            SniperToogle.GetComponent<Toggle>().enabled = true;
            MedicToogle.GetComponent<Toggle>().enabled = true;
            TankToogle.GetComponent<Toggle>().enabled = true;
            SoldierToogle.GetComponent<Toggle>().enabled = false;

            Classe = "Soldier";
        }
    }

    public void TankToogled()
    {
        if (TankToogle.GetComponent<Toggle>().isOn)
        {
            SoldierToogle.GetComponent<Toggle>().isOn = false;
            TankToogle.GetComponent<Toggle>().isOn = true;
            MedicToogle.GetComponent<Toggle>().isOn = false;
            SniperToogle.GetComponent<Toggle>().isOn = false;

            SniperToogle.GetComponent<Toggle>().enabled = true;
            MedicToogle.GetComponent<Toggle>().enabled = true;
            TankToogle.GetComponent<Toggle>().enabled = false;
            SoldierToogle.GetComponent<Toggle>().enabled = true;

            Classe = "Tank";
        }
    }

    public void MedicToogled()
    {
        if (MedicToogle.GetComponent<Toggle>().isOn)
        {
            SoldierToogle.GetComponent<Toggle>().isOn = false;
            TankToogle.GetComponent<Toggle>().isOn = false;
            MedicToogle.GetComponent<Toggle>().isOn = true;
            SniperToogle.GetComponent<Toggle>().isOn = false;

            SniperToogle.GetComponent<Toggle>().enabled = true;
            MedicToogle.GetComponent<Toggle>().enabled = false;
            TankToogle.GetComponent<Toggle>().enabled = true;
            SoldierToogle.GetComponent<Toggle>().enabled = true;

            Classe = "Medic";
        }
    }
}
