using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit_Move_WP : MonoBehaviour {

	public Transform goal;
	public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveHere ()
	{
		agent.destination = goal.position; 
	}
}
