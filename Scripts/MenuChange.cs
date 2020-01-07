using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuChange : MonoBehaviour 
{
	public int Menu = 0;
	public GameObject[] Menus;
	public GameObject[] NextDone;

	void MenuCheck ()
	{
		for (int x = Menus.Length; x > 0; x--) 
		{
			Menus [x-1].SetActive (false);
		}
		if (Menu < 0) 
		{
			Menu = Menus.Length-1;
		}

		if (Menu > Menus.Length-1) 
		{
			Menu = 0;
		}
		Menus [Menu].SetActive (true);
	}

	public void DisableDone()
	{
		NextDone[0].SetActive(true);
		NextDone[1].SetActive(false);
	}

	public void EnableDone()
	{
		if (Menu == Menus.Length-1) 
		{
			NextDone [0].SetActive (false);
			NextDone [1].SetActive (true);
		}
	}

	public void DisableBack()
	{
		if (Menu == 0) 
		{
			NextDone [2].SetActive (false);
		}
	}

	public void EnableBack()
	{
		NextDone[2].SetActive(true);
	}

	public void MenuNext()
	{
		Menu++;
		MenuCheck ();
	}

	public void MenuBack()
	{
		Menu--;
		MenuCheck ();
	}

	public void MenuChangeTo(int MenuNumber)
	{
		Menu = MenuNumber;
		MenuCheck ();
	}
}