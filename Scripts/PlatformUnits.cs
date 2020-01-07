using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUnits : MonoBehaviour {

    public int Knight = 0;
    public int Cavalry = 0;
    public int Airship = 0;
    public float Counter = 0.0f;
    public float timeBetweenSpawns = 1.0f;
    public GameObject GameManager;

    public int knightSerf = 1;
    public int knightIron = 1;

    public int cavalrySerf = 1;
    public int cavalryHorse = 1;

    public int airshipSerf = 1;
    public int airshipCloth = 1;

    // Use this for initialization
    void Start () {
        GameManager = GameObject.Find("GameManager");
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void OnMouseDown()
    {
        if (GameManager.GetComponent<GameManager2>().selectStart)
        {
            GameManager.GetComponent<GameManager2>().platformSelected = this.gameObject;
            GameManager.GetComponent<GameManager2>().selectStart = false;

        }
        else
        {
            if (GameManager.GetComponent<GameManager2>().platformSelected != this.gameObject)
            {
                GameManager.GetComponent<GameManager2>().platformSend = this.gameObject;
            }
        }
    }

    public void createKnight()
    {
        if (GameManager.GetComponent<GameManager2>().serfCounter >= knightSerf && GameManager.GetComponent<GameManager2>().ironCounter >= knightIron)
        {
            GameManager.GetComponent<GameManager2>().serfCounter -= knightSerf;
            GameManager.GetComponent<GameManager2>().ironCounter -= knightIron;
            Knight += 1;
        }
    }

    public void createCavalry()
    {
        if (GameManager.GetComponent<GameManager2>().serfCounter >= cavalrySerf && GameManager.GetComponent<GameManager2>().horseCounter >= cavalryHorse)
        {
            GameManager.GetComponent<GameManager2>().serfCounter -= cavalrySerf;
            GameManager.GetComponent<GameManager2>().horseCounter -= cavalryHorse;
            Cavalry += 1;
        }
    }

    public void createAirship()
    {
        if (GameManager.GetComponent<GameManager2>().serfCounter >= airshipSerf && GameManager.GetComponent<GameManager2>().clothCounter >= airshipCloth)
        {
            GameManager.GetComponent<GameManager2>().serfCounter -= airshipSerf;
            GameManager.GetComponent<GameManager2>().clothCounter -= airshipCloth;
            Airship += 1;
        }
    }
}
