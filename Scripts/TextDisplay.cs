using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextDisplay : MonoBehaviour {

	public bool Enemy = false;
	public bool Level = false;
	public bool Wave = false;
	public float fadeDuration = 1.0f;
	public float currentTimer = 0;

	// Use this for initialization
	void Start () {

		if (Level)
		{
			ShowText (SceneManager.GetActiveScene().buildIndex.ToString());
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTimer > 0) {
			currentTimer -= Time.deltaTime;
			if (currentTimer <= 0 && Enemy == true) {
				if (Wave) {
					this.gameObject.SetActive (false);
				}
				else {
					GetComponent<Text> ().enabled = false;
				}
			}
		}
	}


	public void ShowText (string message)
	{
		if (Level) {
			GetComponent<Text> ().text = "Level " + message;

		} else if (Wave) {
			GetComponent<Text> ().text = "Wave " + message;
		}

		else {
			GetComponent<Text> ().text = message;
		}
		if (!GetComponent<Text>().enabled)
		{
			GetComponent<Text>().enabled = true;
		}
		currentTimer = fadeDuration;
	}
}
