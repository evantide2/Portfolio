using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeMenuInfo : MonoBehaviour {

	public Text BasicTowerText;
	public int BasicTowerPurchaseCosts = 50;

	public int[] UpgradeTowerBaseCosts;
	public int[] StatUpgradeBaseCosts;

	public float[] TowerRangeStats;
	// Use this for initialization
	void Start () {
		BasicTowerDisplay();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BasicTowerDisplay ()
	{
		BasicTowerText.GetComponent<TextDisplay> ().ShowText (BasicTowerPurchaseCosts.ToString ());
	}

}
