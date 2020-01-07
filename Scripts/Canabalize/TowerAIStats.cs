using UnityEngine;
using System.Collections;

public class TowerAIStats : MonoBehaviour {
	
	public int BaseDmg = 1;
	public int CurrentDmg = 1;
	public float baseFireRate = 2.5f;
	public float currentFireRate = 2.5f;
	public bool loaded = true;
	public GameObject targetCreep;
	public GameObject ParentPlatform;

	public bool FrostTower = false;
	public float frostDuration = 2.0f;

	// Use this for initialization
	void Start () {
		ParentPlatform = this.transform.parent.gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
//
//	void OnEnable()
//	{
//		GetComponentInParent<TowerPlatform>

	public void OnTriggerStay (Collider invader)
	{
		if (invader.GetComponent<MoveToWP>().Enemy == true)
		{
			if (invader.GetComponent<CreepStats> () != null) 
			{
				targetCreep = invader.gameObject;
				Fire ();
			}
		}
	}

	public void Fire ()
	{
		if (loaded)
		{
			DetermineFireRate ();
			StartCoroutine(RegFire(currentFireRate));
		}
	}

	IEnumerator RegFire (float fireRate)
	{
		loaded = false;
		DetermineDamage ();
		targetCreep.GetComponent<CreepStats> ().TakeDamage (CurrentDmg);
		if (FrostTower) {
			targetCreep.GetComponent<CreepStats> ().SendMessage ("Frosted", frostDuration);
		}
			
		yield return new WaitForSeconds (fireRate);
		loaded = true;
	}

	public void DetermineDamage()
	{
		CurrentDmg = BaseDmg + ParentPlatform.GetComponent<TowerPlatform> ().AtkUpgrades;
	}

	public void DetermineFireRate()
	{
		currentFireRate = baseFireRate - (ParentPlatform.GetComponent<TowerPlatform> ().SpeedUpgrades * .05f);
	}

}
