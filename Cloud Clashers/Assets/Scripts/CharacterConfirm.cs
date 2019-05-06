using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterConfirm : MonoBehaviour 
{
	

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (SceneManager.GetActiveScene().name == "Character select")
        {

            if (PlayerSelection.P1Ok == true && PlayerSelectionP2.P2Ok == true)
            {
                //FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
                SceneManager.LoadScene("Stage Select");
            }

        }

	}
}
