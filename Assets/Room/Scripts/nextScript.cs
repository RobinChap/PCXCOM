using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextScript : MonoBehaviour {
    public GameObject text;
    public GameObject intro;
    public GameObject teamCreation;
    public GameObject currentRoom;
    public GameObject NextRoom;
    public GameObject Ship;
    public int state = 0;

	// Use this for initialization
	void Start () {
        currentRoom = Ship.GetComponent<ShipScript>().Row2[0];
        NextRoom = Ship.GetComponent<ShipScript>().Row2[1];
        nexttxt();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void nexttxt()
    {
        state++;
        switch (state)
        {
            case 1:
                text.GetComponent<Text>().text = "Bonjour Commandant \n On est dans la merde, ce vaisseau est infesté de saloperies.";
                break;
            case 2:
                text.GetComponent<Text>().text = "Vas falloir construire la meilleure équipe possible, mais on manque un peu de budget.\n Prenez ceux que vous avez sous la main et donnez leur ce que vous pouvez.";
                break;
            case 3:
                text.GetComponent<Text>().text = "Y a X salles, pas besoin de toutes les nettoyer. \n Trouvez et tuez la reine";
                break;
            case 4:
                text.GetComponent<Text>().text = "L'armée a pas le budget pour quoi que ce soit de non conventionnel. \n Mais j'ai passé quelques coups de fils .";
                break;
            case 5:
                text.GetComponent<Text>().text = "C'est pas ultra légal mais faut bien rester en vie \n Bon allez me construire cette équipe !";
                break;
            case 6:
                intro.SetActive(false);
                teamCreation.SetActive(true);
                break;
            case 7:
                intro.SetActive(true);
                teamCreation.SetActive(false);
                text.GetComponent<Text>().text = "Super vous pouvez presqu'y aller \n J'dois encore vous expliquer 2 - 3 trucs";
                break;
            case 8:
                text.GetComponent<Text>().text = "Le matos ici est un peu vieux, alors je vais vous apprendre vite fait les controls.\n ZQSD pour se déplacer - espace pour monter alt gauche pour dessendre.";
                break;
            case 9:
                text.GetComponent<Text>().text = "Vous pouvez changer l'angle horizontal de la caméra avec A et E, le vertical avec un clic droit de la souris \n Enfin vous pouvez stopper le temps avec ENTREE histoire de mieux comprendre la vie";
                break;
            case 10:
                text.GetComponent<Text>().text = "Bon la première salle c'est droit devant, souvenez-vous que c'est pas un jeu, les morts restent morts\n et leur matos (enfin ce que ça a couté) pousse pas sur les arbres";
                break;
            case 11:
                text.GetComponent<Text>().text = "Essayez de pas vous perdre, il parrait qu'il y a une carte dans la salle de la reine.\n Bonne chance";
                break;
            case 12:

                Camera.main.GetComponent<TeamHolder>().ChangeRoom(NextRoom);
                intro.SetActive(false);
                break;
            

        }
    }
}
