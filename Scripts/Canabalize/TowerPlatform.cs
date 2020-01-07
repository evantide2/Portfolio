using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerPlatform : MonoBehaviour {

	public GameObject TowerMenu;
	public int PlatformNumber;
	public bool TowerUp = false;
	public bool TowerTypeUpgraded = false;
	public GameObject[] TowerModels;
	public GameObject[] HighlightBox;
	public int AtkUpgrades = 1;
	public int SpeedUpgrades = 1;

	// Use this for initialization
	void Start () {
		TowerMenu = GameObject.Find ("TowerMenu");
	//	TowerMenu.GetComponent<BuildTower> ().PlatformArray [PlatformNumber] = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown ()
	{
		for (int i = 0; i < TowerMenu.GetComponent<BuildTower>().PlatformArray.Length; i++)
		{
			TowerMenu.GetComponent<BuildTower> ().PlatformArray [i].GetComponent<TowerPlatform>().HighlightBox[0].SetActive (false);
		}

		HighlightBox [0].SetActive (true);

		if (TowerTypeUpgraded) {
			TowerMenu.GetComponent<MenuChange> ().MenuChangeTo (2);
		}
		else if (TowerUp) {
			TowerMenu.GetComponent<MenuChange> ().MenuChangeTo (1);
		} else {
			TowerMenu.GetComponent<MenuChange> ().MenuChangeTo (0);
		}
		TowerMenu.GetComponent<BuildTower>().PlatformSelected = PlatformNumber;
		TowerMenu.GetComponent<TowerStatsDisplay> ().StatMenuUpdate ();
	}
}
