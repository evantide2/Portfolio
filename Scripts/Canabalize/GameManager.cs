using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int gameLevel = 1;
	public int wave = 1;
	public int resources = 100;
	public Text resourceDisplay;
	public Text HPDisplay;
	public int PlayerHealth = 100;
	public GameObject[] DefeatMenu;
	public GameObject[] PauseMenu;


	// Use this for initialization
	void Start () {
		ResourceUpdate (0);
		HPUpdate (0);
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerHealth <= 0) {
			DefeatMenu [0].SetActive (true);
		}
	
	}

	public void ResourceUpdate (int Gains)
	{
		resources += Gains;
		resourceDisplay.SendMessage ("ShowText", resources.ToString());
	}

	public void HPUpdate (int Gains)
	{
		PlayerHealth -= Gains;
		HPDisplay.SendMessage ("ShowText", PlayerHealth.ToString());
	}

	public void Pause()
	{
		PauseMenu [0].SetActive (true);
		Time.timeScale = 0.0f;
	}

	public void Unpause ()
	{
		Time.timeScale = 1.0f;
		PauseMenu [0].SetActive (false);
	}
}
