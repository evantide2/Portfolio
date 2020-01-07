using UnityEngine;
using System.Collections;

public class ChangeWPTarget : MonoBehaviour {

	public bool EndPoint = false;
	public GameObject GameManager;


	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.GetComponent<MoveToWP>().Enemy == true) 
		{
			if (EndPoint && GameManager.GetComponent<GameManager> ().PlayerHealth >0) {
				GameManager.GetComponent<GameManager> ().HPUpdate (other.GetComponent<CreepStats> ().Damage);
			}
				other.gameObject.GetComponent<MoveToWP> ().ChangeTargetWP ();
		}
	}
}
