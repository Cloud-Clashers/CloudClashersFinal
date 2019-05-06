using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour 
{
	public static int PlayerConfirms = 0;

	void Update()
	{
		if (PlayerConfirms == 2) 
		{

			SceneManager.LoadScene ("Game");

		}

	}

	public static void Confirm (int OK)
	{
		PlayerConfirms += OK;
	}


}
