using UnityEngine;
using System.Collections;

public class TowerStatsDisplay : MonoBehaviour {

	public GameObject TowerExample;
	public GameObject TowerRangeHolder;
	public GameObject TowerMenu;
	public GameObject UpdateMenu;
	public GameObject AttackDisplay;
	public GameObject SpeedDisplay;
	public GameObject RangeDisplay;
	public GameObject[] StatDisplay;

	// Use this for initialization
	void Start () {
		StatMenuUpdate ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StatMenuUpdate ()
	{
		if (TowerMenu.GetComponent<MenuChange> ().Menu == 0) {
			StatDisplay [0].SetActive (true);
			AttackDisplay.GetComponent<TextDisplay> ().SendMessage ("ShowText", TowerExample.GetComponent<TowerPlatform> ().TowerModels [0].GetComponent<TowerAIStats> ().BaseDmg.ToString ());
			SpeedDisplay.GetComponent<TextDisplay> ().SendMessage ("ShowText", TowerExample.GetComponent<TowerPlatform> ().TowerModels [0].GetComponent<TowerAIStats> ().baseFireRate.ToString ());
			RangeDisplay.GetComponent<TextDisplay> ().SendMessage ("ShowText", TowerRangeHolder.GetComponent<UpgradeMenuInfo> ().TowerRangeStats [0].ToString ());
		} else if (TowerMenu.GetComponent<MenuChange> ().Menu == 1) {
			StatDisplay [0].SetActive (true);
			AttackDisplay.GetComponent<TextDisplay> ().SendMessage ("ShowText", TowerExample.GetComponent<TowerPlatform> ().TowerModels [UpdateMenu.GetComponent<MenuChange> ().Menu+1].GetComponent<TowerAIStats> ().BaseDmg.ToString ());
			SpeedDisplay.GetComponent<TextDisplay> ().SendMessage ("ShowText", TowerExample.GetComponent<TowerPlatform> ().TowerModels [UpdateMenu.GetComponent<MenuChange> ().Menu+1].GetComponent<TowerAIStats> ().baseFireRate.ToString ());
			RangeDisplay.GetComponent<TextDisplay> ().SendMessage ("ShowText", TowerRangeHolder.GetComponent<UpgradeMenuInfo> ().TowerRangeStats [UpdateMenu.GetComponent<MenuChange> ().Menu+1].ToString ());
		} else {
			StatDisplay [0].SetActive (false);
		}
	}
}
