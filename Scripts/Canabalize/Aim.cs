using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	public Transform targetPos;

	// Use this for initialization
	void Start () 
	{
		targetPos = transform.parent.Find ("Reticle");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (targetPos);
		Vector3 lockedAngle = transform.rotation.eulerAngles;
		lockedAngle = new Vector3 (0, lockedAngle.y, 0);
		transform.rotation = Quaternion.Euler (lockedAngle);
	}
}
