using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class ButtonNavigation : MonoBehaviour 
{

	int index = 0;
	public int totalLevels = 4;
	public float yOffset = 1f;

    public GameObject PlayerOn;
    public GameObject PlayerOff;
    public GameObject InstructionOn;
    public GameObject InstructionOff;
	public GameObject CreditsOn;
	public GameObject CreditsOff;
    public GameObject QuitOn;
    public GameObject QuitOff;

    bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");

        
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

        if (index == 0)
        {

            PlayerOn.SetActive (true);
            PlayerOff.SetActive(false);
            InstructionOn.SetActive(false);
            InstructionOff.SetActive(true);
			CreditsOn.SetActive(false);
			CreditsOff.SetActive(true);
            QuitOn.SetActive(false);
            QuitOff.SetActive(true);


        }

        if (index == 1)
        {

            PlayerOn.SetActive(false);
            PlayerOff.SetActive(true);
            InstructionOn.SetActive(true);
            InstructionOff.SetActive(false);
			CreditsOn.SetActive(false);
			CreditsOff.SetActive(true);
            QuitOn.SetActive(false);
            QuitOff.SetActive(true);

        }

        if (index == 2)
        {
            PlayerOn.SetActive(false);
            PlayerOff.SetActive(true);
            InstructionOn.SetActive(false);
            InstructionOff.SetActive(true);
			CreditsOn.SetActive(true);
			CreditsOff.SetActive(false);
			QuitOn.SetActive(false);
			QuitOff.SetActive(true);
        }

		if (index == 3)
		{
			PlayerOn.SetActive(false);
			PlayerOff.SetActive(true);
			InstructionOn.SetActive(false);
			InstructionOff.SetActive(true);
			CreditsOn.SetActive(false);
			CreditsOff.SetActive(true);
			QuitOn.SetActive(true);
			QuitOff.SetActive(false);
		}


        if (Input.GetKeyDown (KeyCode.DownArrow) || prevState.DPad.Down == ButtonState.Pressed && state.DPad.Down == ButtonState.Released )
		{
            FindObjectOfType<AudioManager>().Play("Navigate");



            if (index < totalLevels - 1) 
				{
					index++;
					Vector2 Position = transform.position;
					Position.y -= yOffset;
					transform.position = Position;
				}

		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || prevState.DPad.Up == ButtonState.Pressed && state.DPad.Up == ButtonState.Released )
		{
            FindObjectOfType<AudioManager>().Play("Navigate");

            if (index > 0) 
				{
					index--;
					Vector2 Position = transform.position;
					Position.y += yOffset;
					transform.position = Position;
				}
		}

		if (Input.GetKeyDown (KeyCode.Return) || Input.GetButtonDown("P1A"))
		{

            FindObjectOfType<AudioManager>().Play("Select");

            if (index == 0) 
			{
                //FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
                //FindObjectOfType<AudioManager>().Play("CharacterSelectTheme");
                SceneManager.LoadScene ("Character Select");


            }

            if (index == 1)
            {

                SceneManager.LoadScene("Instructions");

            }

			if (index == 2)
			{

				SceneManager.LoadScene("Credits");

			}


            if (index == 3) 
			{
                Application.Quit();
            }
				
		}



	}

}
