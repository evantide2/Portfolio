using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreepStats : MonoBehaviour {

	public int maxhp = 3;
	public int currentHP = 3;
	public float maxSpeed = 3.5f;
	GameObject gameManager;
	GameObject Spawner;
	public int resourcePerKill = 20;
	public int Damage = 1;

	public int Defense = 0;
	public UnityEngine.AI.NavMeshAgent agent;

	public GameObject[] DmgText;
	public GameObject HealthBar;


	// Use this for initialization
	void Start () {

		gameManager = GameObject.Find ("GameManager");
		Spawner = GameObject.Find ("SpawnerObj");
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		InitializeValues ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHP < 1) {
			gameManager.SendMessage ("ResourceUpdate", resourcePerKill);
			Spawner.SendMessage ("KillCountIncrement");
			this.GetComponent<MoveToWP> ().SecondWave = true;
			this.GetComponent<MoveToWP> ().StartMove ();

			InitializeValues ();

			gameObject.SetActive (false);
		}

	}

	public void InitializeValues()
	{

		DmgText [0].SetActive (false);

		currentHP = maxhp;

		HealthBar.GetComponent<Slider> ().maxValue = maxhp;
		HealthBar.GetComponent<Slider> ().value = currentHP;

		agent.speed = maxSpeed;

	}

	public IEnumerator Frosted (float frostDuration)
	{
		agent.speed = maxSpeed * .5f;
		yield return new WaitForSeconds (frostDuration);
		agent.speed = maxSpeed;
	}

	public void TakeDamage(int Dmg)
	{
		Dmg -= Defense;
		if (Dmg <= 0) {
			Dmg = 0;
		}
		currentHP -= Dmg;
		DmgText [0].SetActive (true);
		DmgText[0].SendMessage ("ShowText", (-Dmg).ToString());
		HealthBar.GetComponent<Slider> ().value = currentHP;
	}
}
