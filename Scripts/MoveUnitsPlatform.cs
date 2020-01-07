using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnitsPlatform : MonoBehaviour {

    public int UnitCount = 0;
    public GameObject GameManager;
    public int UnitTypeToSend = 0;


    // Use this for initialization
    void Start () {
        GameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SendAllUnits()
    {
		GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner>().endLoc = GameManager.GetComponent<GameManager2>().platformSend.transform.GetChild(0).gameObject;

		GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<GameManager2>().spawnEndLocUpdate();

        if (UnitTypeToSend == 0)
        {
            UnitCount = GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Knight;
            GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Knight = 0;
            GameManager.GetComponent<GameManager2>().platformSend.GetComponent<PlatformUnits>().Knight += UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner>().SpawnNum = UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner> ().SpawnKnights();

        }
        if(UnitTypeToSend == 1)
        {
            UnitCount = GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Cavalry;
            GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Cavalry = 0;
            GameManager.GetComponent<GameManager2>().platformSend.GetComponent<PlatformUnits>().Cavalry += UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner>().SpawnNum = UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner> ().SpawnCavalrys();
        }
        if(UnitTypeToSend == 2)
        {
            UnitCount = GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Airship;
            GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Airship = 0;
            GameManager.GetComponent<GameManager2>().platformSend.GetComponent<PlatformUnits>().Airship += UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner>().SpawnNum = UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner> ().SpawnAirships();
        }
        UnitCount = 0;
    }

    public void SendHalfUnits()
    {
		GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner>().endLoc = GameManager.GetComponent<GameManager2>().platformSend.transform.GetChild(0).gameObject;
		GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<GameManager2>().spawnEndLocUpdate();
		if (UnitTypeToSend == 0)
        {
            UnitCount = GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Knight / 2;
            GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Knight -= UnitCount;
            GameManager.GetComponent<GameManager2>().platformSend.GetComponent<PlatformUnits>().Knight += UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner>().SpawnNum = UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner> ().SpawnKnights();
        }
        if (UnitTypeToSend == 1)
        {
            UnitCount = GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Cavalry / 2;
            GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Cavalry -= UnitCount;
            GameManager.GetComponent<GameManager2>().platformSend.GetComponent<PlatformUnits>().Cavalry += UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner>().SpawnNum = UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner> ().SpawnCavalrys();
        }
        if (UnitTypeToSend == 2)
        {
            UnitCount = GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Airship / 2;
            GameManager.GetComponent<GameManager2>().platformSelected.GetComponent<PlatformUnits>().Airship -= UnitCount;
            GameManager.GetComponent<GameManager2>().platformSend.GetComponent<PlatformUnits>().Airship += UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner>().SpawnNum = UnitCount;
			GameManager.GetComponent<GameManager2> ().platformSelected.GetComponent<Spawner> ().SpawnAirships();
        }
        UnitCount = 0;
    }

    public void SetUnitType(int UnitTypeNum)
    {
        UnitTypeToSend = UnitTypeNum;
    }
}
