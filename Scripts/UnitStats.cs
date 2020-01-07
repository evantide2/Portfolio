using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour {

    public int numHealth = 6;
    public int unitType = 0; //0 is town, 1 knight, 2 cav, 3 airship
    public bool Allied = true; //1 is allied, 0 is enemy.
    public int baseDamage = 2;
    public int multiplierStrongAgainst = 2;
    public int multiplierWeakAgainst = 2;
    public GameObject enemyObject;
    public GameObject GameManager;

	// Use this for initialization
	void Start ()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Allied != hit.gameObject.GetComponent<UnitStats>().Allied)
        {
            enemyObject = hit.gameObject;
            if (unitType == 0)
            {
                TownResponse();
            }
            else if (unitType == 1)
            {
                KnightResponse();
            }
            else if (unitType == 2)
            {
                CavalryResponse();
            }
            else
            {
                AirshipResponse();
            }
        }
    }

    public void DeathCheck ()
    {
        if (numHealth <= 0 && unitType == 0) //town flip flop
        {
            if (Allied)
            {
                Allied = false;
                GameManager.GetComponent<GameManager2>().townsControlled -= 1;
            }
            else
            {
                Allied = true;
                GameManager.GetComponent<GameManager2>().townsControlled += 1;
            }
            numHealth = 20;
        }
        else if (numHealth <= 0)
        {
            Destroy(this);
        }
    }

    public void TownResponse ()
    {
        enemyObject.GetComponent<UnitStats>().numHealth = 0;
    }

    public void KnightResponse ()
    {
        if (enemyObject.GetComponent<UnitStats>().unitType == 2)
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= (baseDamage / multiplierWeakAgainst);
        }
        else if (enemyObject.GetComponent<UnitStats>().unitType == 3)
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= (baseDamage * multiplierStrongAgainst);
        }
        else
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= baseDamage;
        }
        DeathCheck();
    }

    public void CavalryResponse ()
    {
        if (enemyObject.GetComponent<UnitStats>().unitType == 3)
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= (baseDamage / multiplierWeakAgainst);
        }
        else if (enemyObject.GetComponent<UnitStats>().unitType == 1)
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= (baseDamage * multiplierStrongAgainst);
        }
        else
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= baseDamage;
        }
        DeathCheck();
    }

    public void AirshipResponse ()
    {
        if (enemyObject.GetComponent<UnitStats>().unitType == 1)
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= (baseDamage / multiplierWeakAgainst);
        }
        else if (enemyObject.GetComponent<UnitStats>().unitType == 2)
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= (baseDamage * multiplierStrongAgainst);
        }
        else
        {
            enemyObject.GetComponent<UnitStats>().numHealth -= baseDamage;
        }
        DeathCheck();
    }
}
