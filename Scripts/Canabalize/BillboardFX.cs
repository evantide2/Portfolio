using UnityEngine;
using System.Collections;

public class BillboardFX : MonoBehaviour {

	public GameObject main;

	// Use this for initialization
	void Start () {
		main = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = main.transform.forward;
	}
}
