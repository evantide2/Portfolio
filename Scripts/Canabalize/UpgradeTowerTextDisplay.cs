using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeTowerTextDisplay : MonoBehaviour {

	public GameObject UpgradeInfoStorage;
	public bool TowerUpgrade = true;
	public int UpgradeNumber;
	public GameObject BuildTowerMenu;
	public bool isAttackUpgradeBits = false;

	// Use this for initialization
	void Start () {
		if (TowerUpgrade)
		{
			ShowText(UpgradeInfoStorage.GetComponent<UpgradeMenuInfo>().UpgradeTowerBaseCosts[UpgradeNumber].ToString());
				}
				else{
			UpdatStatBitCost();
			}

	}
		
	public void ShowText (string message)
	{
		GetComponent<Text>().text = message;
		if (!GetComponent<Text>().enabled)
		{
			GetComponent<Text>().enabled = true;
		}
	}

	public void UpdatStatBitCost ()
	{
		if (isAttackUpgradeBits) {
			ShowText ((UpgradeInfoStorage.GetComponent<UpgradeMenuInfo> ().StatUpgradeBaseCosts [UpgradeNumber] * BuildTowerMenu.GetComponent<BuildTower> ().PlatformArray [BuildTowerMenu.GetComponent<BuildTower> ().PlatformSelected].GetComponent<TowerPlatform> ().AtkUpgrades).ToString ());
		} else {
			ShowText ((UpgradeInfoStorage.GetComponent<UpgradeMenuInfo> ().StatUpgradeBaseCosts [UpgradeNumber] * BuildTowerMenu.GetComponent<BuildTower> ().PlatformArray [BuildTowerMenu.GetComponent<BuildTower> ().PlatformSelected].GetComponent<TowerPlatform> ().SpeedUpgrades).ToString ());
		}
	}
}