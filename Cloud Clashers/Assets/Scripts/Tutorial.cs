using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour 
{
	public AudioSource Audio;
	public AudioClip Navigate;

	int index = 0;
	public int totalLevels = 2;

	public GameObject CharacterSelect;
	public GameObject GameControls;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (index == 0) 
		{
			CharacterSelect.SetActive (false);

			GameControls.SetActive (true);
		}

		if (index == 1) 
		{
			GameControls.SetActive (false);

			CharacterSelect.SetActive (true);
		}

		if (Input.GetButtonDown ("P1RB"))
		{
			Audio.PlayOneShot(Navigate);

			if (index < totalLevels - 1) 
			{
				index++;
			}

		}

		if (Input.GetButtonDown ("P1LB"))
		{
			Audio.PlayOneShot(Navigate);

			if (index > 0) 
			{
				index--;
			}
		}

		if (Input.GetButtonDown ("P1B"))
		{

			SceneManager.LoadScene ("Main Menu");

		}

	}
}
