using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour {

    public GameObject platformSelected;
    public GameObject platformSend;
    public bool selectStart = true;
    public Text[] PrimaryNumDisplay;
    public Text[] SecondaryNumDisplay;
    public Text[] ResourceNumDisplay;
    public float Counter = 0.0f;

    public int serfCounter = 0;
    public int ironCounter = 0;
    public int horseCounter = 0;
    public int clothCounter = 0;

    public int townsControlled = 1;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        Counter += Time.deltaTime;
        if (Counter >= 1)
        {
            if (platformSelected != null)
            {
                platformSelectedUnitsUpdate();
            }
            if (platformSend != null)
            {
                platformSendUnitsUpdate();
            }
            resourceIncrease();
            resourceTextUpdate();
            Counter = 0;
        }
    }

    public void spawnEndLocUpdate ()
    {
        platformSelected.GetComponent<Spawner>().endLoc = platformSend;
    }

    public void resourceIncrease()
    {
        serfCounter += townsControlled;
        ironCounter += townsControlled;
        horseCounter += townsControlled;
        clothCounter += townsControlled;
    }

    public void resourceTextUpdate()
    {
        ResourceNumDisplay[0].text = serfCounter.ToString();
        ResourceNumDisplay[1].text = ironCounter.ToString();
        ResourceNumDisplay[2].text = horseCounter.ToString();
        ResourceNumDisplay[3].text = clothCounter.ToString();
    }

    public void platformSelectedUnitsUpdate()
    {
        PrimaryNumDisplay[0].text = platformSelected.GetComponent<PlatformUnits>().Knight.ToString();
        PrimaryNumDisplay[1].text = platformSelected.GetComponent<PlatformUnits>().Cavalry.ToString();
        PrimaryNumDisplay[2].text = platformSelected.GetComponent<PlatformUnits>().Airship.ToString();
    }

    public void platformSendUnitsUpdate()
    {
        SecondaryNumDisplay[0].text = platformSend.GetComponent<PlatformUnits>().Knight.ToString();
        SecondaryNumDisplay[1].text = platformSend.GetComponent<PlatformUnits>().Cavalry.ToString();
        SecondaryNumDisplay[2].text = platformSend.GetComponent<PlatformUnits>().Airship.ToString();
    }

    public void MakeKnight ()
    {
        platformSelected.GetComponent<PlatformUnits>().createKnight();
    }

    public void MakeCavalry()
    {
        platformSelected.GetComponent<PlatformUnits>().createCavalry();
    }

    public void MakeAirship()
    {
        platformSelected.GetComponent<PlatformUnits>().createAirship();
    }
}
