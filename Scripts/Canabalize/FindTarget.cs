using UnityEngine;
using System.Collections;

public class FindTarget : MonoBehaviour {

	public float speed = 15f;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
		target = transform.parent.Find ("Dummy").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
		target = transform.parent.gameObject.GetComponent<TowerAIStats>().targetCreep;

		if (target.GetComponent<CreepStats>() != null)
		{
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * speed);
			if ((target.transform.position == transform.position))
			{
				Debug.Log("Fire");
				transform.parent.GetComponent<TowerAIStats>().Fire();
			}
		}
	}
}
