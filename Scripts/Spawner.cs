using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject spawnLoc;
    public GameObject endLoc;
    public int SpawnNum = 0;
    public float spawnRate = 1.0f;

    //Prefabs of Enemies
    public GameObject Knight;
    public GameObject Cavalry;
    public GameObject Airship;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnKnights()
    {
        for (int i = 0; i < SpawnNum; i++)
        {
            GameObject KnightCreep = Instantiate(Knight, spawnLoc.transform.position, spawnLoc.transform.rotation) as GameObject;
            KnightCreep.name = "Knight";
			KnightCreep.GetComponent <Unit_Move_WP> ().goal = endLoc.transform.GetChild(0).transform;
        }
    }

    public void SpawnCavalrys()
    {
        for (int i = 0; i < SpawnNum; i++)
        {
            GameObject CavalryCreep = Instantiate(Cavalry, spawnLoc.transform.position, spawnLoc.transform.rotation) as GameObject;
            CavalryCreep.name = "Cavalry";
            CavalryCreep.GetComponent<Unit_Move_WP>().goal = endLoc.transform.GetChild(0).transform;

        }
    }


    public void SpawnAirships()
    {
        for (int i = 0; i < SpawnNum; i++)
        {
            GameObject AirshipCreep = Instantiate(Airship, spawnLoc.transform.position, spawnLoc.transform.rotation) as GameObject;
            AirshipCreep.name = "Airship";
            AirshipCreep.GetComponent<Unit_Move_WP>().goal = endLoc.transform.GetChild(0).transform;

        }
    }
}
