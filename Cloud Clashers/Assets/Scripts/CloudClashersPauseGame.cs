using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class CloudClashersPauseGame : MonoBehaviour 
{
	public GameObject PauseBackground;

	public GameObject ResetOn;
	public GameObject ResetOff;
	public GameObject CharacterSelectOn;
	public GameObject CharacterSelectOff;
	public GameObject QuitOn;
	public GameObject QuitOff;

	public GameObject Volume;

	public bool Option = false;

	public int menuindex = 0;
	public int totalLevels = 4;
	public float yOffset = 1f;

	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	private bool paused = false;

	void Start()
	{
		PauseBackground.SetActive (false);

        playerIndex = PlayerIndex.One;
    }

	
	// Update is called once per frame
	void Update () 
	{

		if (!playerIndexSet || !prevState.IsConnected)
		{
			for (int i = 0; i < 4; ++i)
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}

		prevState = state;
		state = GamePad.GetState(playerIndex);

       
         if (prevState.Buttons.Start == ButtonState.Released && state.Buttons.Start == ButtonState.Pressed)
         {
             if (paused)
             {
                Resume();
             }
              else
              {
                 Pause();
              }
         }

        

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (paused) 
			{
				Resume ();
			} 
			else 
			{
				Pause ();
			}
		}

        
        

        if (prevState.DPad.Down == ButtonState.Pressed && state.DPad.Down == ButtonState.Released)
        {
             if (menuindex < totalLevels - 1)
             {
                    menuindex++;
                    Vector2 Position = transform.position;
                    Position.y -= yOffset;
                    transform.position = Position;
             }
        }


         if (prevState.DPad.Up == ButtonState.Pressed && state.DPad.Up == ButtonState.Released)
         {
             if (menuindex > 0)
             {
                    menuindex--;
                    Vector2 Position = transform.position;
                    Position.y += yOffset;
                    transform.position = Position;
             }
         }

        

		if (menuindex == 0) 
		{
			
			ResetOn.SetActive (true);
			ResetOff.SetActive (false);
			CharacterSelectOn.SetActive (false);
			CharacterSelectOff.SetActive (true);
			QuitOn.SetActive (false);
			QuitOff.SetActive (true);

		}

		if (menuindex == 1) 
		{

			ResetOn.SetActive (false);
			ResetOff.SetActive (true);
			CharacterSelectOn.SetActive (true);
			CharacterSelectOff.SetActive (false);
			QuitOn.SetActive (false);
			QuitOff.SetActive (true);


		}

		if (menuindex == 2) 
		{

			ResetOn.SetActive (false);
			ResetOff.SetActive (true);
			CharacterSelectOn.SetActive (false);
			CharacterSelectOff.SetActive (true);
			QuitOn.SetActive (true);
			QuitOff.SetActive (false);
		}


		if (paused) 
		{
			

			if (Input.GetButtonDown ("P1A") && menuindex == 0) 
			{
                FindObjectOfType<AudioManager>().Stop("Theme");
                Application.LoadLevel (Application.loadedLevel);
				Resume ();

			}

            if (SceneManager.GetActiveScene().name == "Game")
            {
                if (Input.GetButtonDown("P1A") && menuindex == 1)
                {

                    SceneManager.LoadScene("Character Select");
                    PlayerSelection.P1Ok = false;
                    PlayerSelectionP2.P2Ok = false;
                    FindObjectOfType<AudioManager>().Stop("Theme");
					FindObjectOfType<AudioManager>().Play("MainMenuTheme");
                    Resume();

                }
            }

			if (SceneManager.GetActiveScene().name == "Game")
			{

				if (Input.GetButtonDown("P1A") && menuindex == 2)
				{

					SceneManager.LoadScene("Main menu");
					FindObjectOfType<AudioManager>().Stop("Theme");
					FindObjectOfType<AudioManager>().Play("MainMenuTheme");
					PlayerSelection.P1Ok = false;
					PlayerSelectionP2.P2Ok = false;
					Resume();

				}

            }

		}



	}

	public void Resume()
	{
		PauseBackground.SetActive (false);

		Time.timeScale = 1;
		paused = false;
	}

	void Pause()
	{
		PauseBackground.SetActive (true);
	
		Time.timeScale = 0;
		paused = true;
	}

}
