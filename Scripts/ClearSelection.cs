using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSelection : MonoBehaviour {

    public GameObject GameManager;

    // Use this for initialization
    void Start()
    {
        GameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ClearPlatform()
    {
        GameManager.GetComponent<GameManager2>().platformSelected = null;
        GameManager.GetComponent<GameManager2>().platformSend = null;
        GameManager.GetComponent<GameManager2>().selectStart = true;
        GameManager.GetComponent<Spawner>().spawnLoc = null;
        GameManager.GetComponent<Spawner>().endLoc = null;

        for (int x = 0; x < 3; x++)
        {
            GameManager.GetComponent<GameManager2>().PrimaryNumDisplay[x].text = "0";
            GameManager.GetComponent<GameManager2>().SecondaryNumDisplay[x].text = "0";
        }
    }
}
