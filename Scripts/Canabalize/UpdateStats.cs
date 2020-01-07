using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour {

	public GameObject AttackDisplayHUD;
	public GameObject SpeedDisplayHUD;

	// Use this for initialization
	void Start () {
		DisplayAttack (1);
		DisplaySpeed (1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DisplayAttack (int AtkUpgrades)
	{
		AttackDisplayHUD.SendMessage ("ShowText", AtkUpgrades.ToString());
	}

	public void DisplaySpeed (int SpeedUpgrades)
	{
		SpeedDisplayHUD.SendMessage ("ShowText", SpeedUpgrades.ToString());
	}
}
