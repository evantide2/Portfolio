using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]

//created the following as a class so takes up less space in inspector
//lists the creep then how many creeps in wave for designer to adjust

public class CreatesWave
{
	public int[] EnemiesInWave;
}
	
public class Spawner1 : MonoBehaviour {

	public GameObject[] WayPointsLevel1 = new GameObject[5];
	public GameObject spawnLoc;
	public GameObject startPoint;

	//Prefabs of Enemies
	public GameObject Wolf;
	public GameObject Skeleton;
	public GameObject Zombie;
	public GameObject Werewolf;

	//creates arrays for each creature group
	private GameObject[] PenWolf;
	private GameObject[] PenSkeleton;
	private GameObject[] PenZombie;
	private GameObject[] PenWerewolf;

	//creating a variable to us as a conter
	public int NumWolves;
	public int NumSkeletons;
	public int NumZombies;
	public int NumWerewolves;

	public int numberPerTypeToMake = 50;

	//WaveCounter
	public int WaveNumber = 0;

	public float spawnRate = 0.7f;

	//instantiates the class so our Spawner Class can use it
	public CreatesWave[] Waves;

	public int TotalCreeps = 0;
	public int KillCount = 0;

	public GameObject[] VictoryMenu;

	public bool CanStartNextWave = true;

	public GameObject WaveCounterHUD;

	public GameObject[] WaveCounterGUIText;

	void Start()
	{
		//here I create holding arrays for each creep we are going to make.
		//this way we can activate/deactivate them easily
		PenWolf = new GameObject[numberPerTypeToMake];
		PenSkeleton = new GameObject[numberPerTypeToMake];
		PenZombie = new GameObject[numberPerTypeToMake];
		PenWerewolf = new GameObject[numberPerTypeToMake];

		//starts instantiating the creeps, stores them, then deactivates them
		CreateCreeps (numberPerTypeToMake, numberPerTypeToMake, numberPerTypeToMake, numberPerTypeToMake);

	}

	public void LaunchWave()
	{
		if (CanStartNextWave) {
			//cache number so it can iterate without using a property
			NumWolves = Waves [WaveNumber].EnemiesInWave [0];
			NumSkeletons = Waves [WaveNumber].EnemiesInWave [1];
			NumZombies = Waves [WaveNumber].EnemiesInWave [2];
			NumWerewolves = Waves [WaveNumber].EnemiesInWave [3];

			//Moves Creeps to starting area and activates them
			StartCoroutine (LaunchCreeps (spawnRate, NumWolves, NumSkeletons, NumZombies, NumWerewolves));

			CanStartNextWave = false;
		}
	}

	void CreateCreeps (int Mon1, int Mon2, int Mon3, int Mon4)
	{
		//A series of foreach statements (one per creep type) to spawn the creeps all at once
		//when the wave loads.
		for (int i = 0; i < Mon1; i++) {
			GameObject WolfCreep = Instantiate (Wolf, spawnLoc.transform.position, spawnLoc.transform.rotation) as GameObject;
			WolfCreep.name = "Wolf";
			PenWolf [i] = WolfCreep;
			PenWolf [i].SetActive (false);
		}

		for (int i = 0; i < Mon2; i++) {
			GameObject SkeletonCreep = Instantiate (Skeleton, spawnLoc.transform.position, spawnLoc.transform.rotation) as GameObject;
			SkeletonCreep.name = "Skeleton";
			PenSkeleton [i] = SkeletonCreep;
			PenSkeleton [i].SetActive (false);
		}

		for (int i = 0; i < Mon3; i++) {
			GameObject ZombieCreep = Instantiate (Zombie, spawnLoc.transform.position, spawnLoc.transform.rotation) as GameObject;
			ZombieCreep.name = "Zombie";
			PenZombie [i] = ZombieCreep;
			PenZombie [i].SetActive (false);
		}

		for (int i = 0; i < Mon4; i++) {
			GameObject WerewolfCreep = Instantiate (Werewolf, spawnLoc.transform.position, spawnLoc.transform.rotation) as GameObject;
			WerewolfCreep.name = "Werewolf";
			PenWerewolf [i] = WerewolfCreep;
			PenWerewolf [i].SetActive (false);
		}
	}

	public void KillCountIncrement ()
	{
		KillCount++;
		if (KillCount >= TotalCreeps) {
			WaveNumberIncrement();
			if (WaveNumber == Waves.Length) {
				VictoryMenu [0].SetActive (true);
			}
			if (WaveNumber < Waves.Length)
				{
				WaveCounterGUIText[0].SetActive (true);
				WaveCounterGUIText [0].GetComponent<TextDisplay>().SendMessage ("ShowText", (WaveNumber + 1).ToString ());
				CanStartNextWave = true;
				}
		}
	}

	public void WaveNumberIncrement ()
	{
		WaveNumber++;
		WaveCounterHUD.SendMessage ("ShowText", (WaveNumber+1).ToString());
	}

			

	IEnumerator LaunchCreeps(float spawnRate, int Mon1, int Mon2, int Mon3, int Mon4)
	{
		TotalCreeps = TotalCreeps + Mon1 + Mon2 + Mon3 + Mon4;
		for (int i = 0; i < Mon1; i++) {
			PenWolf [i].transform.position = startPoint.transform.position;
			PenWolf [i].SetActive (true);
			PenWolf [i].GetComponent<MoveToWP> ().CheckIfSecondWave ();
			yield return new WaitForSeconds (spawnRate);
		}

		for (int i = 0; i < Mon2; i++) {
			PenSkeleton [i].transform.position = startPoint.transform.position;
			PenSkeleton [i].SetActive (true);
			PenSkeleton [i].GetComponent<MoveToWP> ().CheckIfSecondWave ();
			yield return new WaitForSeconds (spawnRate);
		}

		for (int i = 0; i < Mon3; i++) {
			PenZombie [i].transform.position = startPoint.transform.position;
			PenZombie [i].SetActive (true);
			PenZombie [i].GetComponent<MoveToWP> ().CheckIfSecondWave ();
			yield return new WaitForSeconds (spawnRate);
		}

		for (int i = 0; i < Mon4; i++) {
			PenWerewolf [i].transform.position = startPoint.transform.position;
			PenWerewolf [i].SetActive (true);
			PenWerewolf [i].GetComponent<MoveToWP> ().CheckIfSecondWave ();
			yield return new WaitForSeconds (spawnRate);
		}
	}
}
