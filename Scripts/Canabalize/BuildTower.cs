using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildTower : MonoBehaviour {

	public TowerPlatform[] PlatformArray; 
	public int PlatformSelected = 0;
	public GameObject GameManager;
	public GameObject UpgradeMenuStorage;
	public int i = 0;
	public GameObject UpgradeMenu;
	public GameObject StatMenu;

	// Use this for initialization
	void Start () {

		PlatformArray= FindObjectsOfType(typeof(TowerPlatform)) as TowerPlatform[];
		foreach (TowerPlatform Platform in PlatformArray) {
			Platform.GetComponent<TowerPlatform> ().PlatformNumber = i;
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BuildTheTower()
	{
		if (GameManager.GetComponent<GameManager> ().resources >= UpgradeMenuStorage.GetComponent<UpgradeMenuInfo>().BasicTowerPurchaseCosts) {
			if (PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerUp == false) {
				PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerModels [0].SetActive (true);
				PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerUp = true;
				GameManager.GetComponent<GameManager> ().ResourceUpdate (-UpgradeMenuStorage.GetComponent<UpgradeMenuInfo>().BasicTowerPurchaseCosts);
				gameObject.GetComponent<MenuChange> ().MenuChangeTo (1);
			}
		}
	}

	public void UpgradeTower()
	{
		if (GameManager.GetComponent<GameManager> ().resources >= UpgradeMenuStorage.GetComponent<UpgradeMenuInfo> ().UpgradeTowerBaseCosts [UpgradeMenu.GetComponent<MenuChange> ().Menu]) 
		{

				for (int i = 0; i <= PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerModels.Length - 1; i++) {
					PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerModels [i].SetActive (false);
				}
				PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerTypeUpgraded = true;
				PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerModels [UpgradeMenu.GetComponent<MenuChange> ().Menu + 1].SetActive (true);
			GameManager.GetComponent<GameManager> ().ResourceUpdate (-UpgradeMenuStorage.GetComponent<UpgradeMenuInfo> ().UpgradeTowerBaseCosts [UpgradeMenu.GetComponent<MenuChange> ().Menu]);
				gameObject.GetComponent<MenuChange> ().MenuChangeTo (2);
		}
	}

	public void UpgradeStats()
	{
		if (StatMenu.GetComponent<MenuChange> ().Menu == 0) {
			if (GameManager.GetComponent<GameManager> ().resources >= (UpgradeMenuStorage.GetComponent<UpgradeMenuInfo> ().StatUpgradeBaseCosts [StatMenu.GetComponent<MenuChange> ().Menu] * PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().AtkUpgrades)) {
				GameManager.GetComponent<GameManager> ().ResourceUpdate (-(UpgradeMenuStorage.GetComponent<UpgradeMenuInfo> ().StatUpgradeBaseCosts [StatMenu.GetComponent<MenuChange> ().Menu] * PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().AtkUpgrades));

				PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().AtkUpgrades++;
				StatMenu.GetComponent<UpdateStats> ().SendMessage ("DisplayAttack", (PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().AtkUpgrades));
			}

		} else {
			if (GameManager.GetComponent<GameManager> ().resources >= (UpgradeMenuStorage.GetComponent<UpgradeMenuInfo> ().StatUpgradeBaseCosts [StatMenu.GetComponent<MenuChange> ().Menu] * PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().SpeedUpgrades)) {
				GameManager.GetComponent<GameManager> ().ResourceUpdate (-(UpgradeMenuStorage.GetComponent<UpgradeMenuInfo> ().StatUpgradeBaseCosts [StatMenu.GetComponent<MenuChange> ().Menu] * PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().SpeedUpgrades));
				PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().SpeedUpgrades++;
				StatMenu.GetComponent<UpdateStats> ().SendMessage ("DisplaySpeed", (PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().SpeedUpgrades));
			}
		}

	}

	public void SellTower()
	{
		if (PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerUp == true) {
			for (int i = 0; i <= PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerModels.Length-1; i++)
			{
				PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerModels [i].SetActive (false);
			}
			PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerUp = false;
			PlatformArray [PlatformSelected].GetComponent<TowerPlatform> ().TowerTypeUpgraded = false;
			gameObject.GetComponent<MenuChange> ().MenuChangeTo (0);
			GameManager.GetComponent<GameManager> ().ResourceUpdate (20);
		}
	}
}
