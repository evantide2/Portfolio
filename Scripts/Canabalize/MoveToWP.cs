using UnityEngine;
using System.Collections;

public class MoveToWP : MonoBehaviour {

	public bool Enemy = true;
	public GameObject Path;
	public WaypointHolder pathScript;
	public GameObject targetVector;
	public int wayIndex;
	public float speed = .5f;
	public UnityEngine.AI.NavMeshAgent agent;
	GameObject Spawner;
	public bool SecondWave = false;


	// Use this for initialization
	void Start () {
		Path = GameObject.Find ("WP Holder");
		wayIndex = 0;
		pathScript = Path.GetComponent<WaypointHolder>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		StartMove ();
		Spawner = GameObject.Find ("SpawnerObj");

	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void CheckIfSecondWave()
	{
		if (SecondWave) {
			wayIndex = 0;
			StartMove ();
		}
	}

	public void StartMove()
	{
		targetVector = pathScript.WayPoints[wayIndex];
		agent.destination = targetVector.transform.position;
	}

	public void ChangeTargetWP()
	{
		if (wayIndex < pathScript.WayPoints.Length - 1) {
			//oldPos = this.transform.position;
			wayIndex++;
			StartMove ();
		} 
		else
		{
			Spawner.SendMessage ("KillCountIncrement");
			SecondWave = true;
			gameObject.SetActive (false);
		}
	}
		
}