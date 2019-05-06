using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using XInputDotNetPure;

public class PlayerSelectionP4 : MonoBehaviour 
{

	bool playerIndexSet = false;
	public PlayerIndex playerIndex = PlayerIndex.Four;
	GamePadState state;
	GamePadState prevState;
	static public bool P4Ok = false;
	public int TotalOptions = 2;


	//Player1
	public SpriteRenderer P4part;
	public SpriteRenderer P4part2;
	public Sprite[] CharOptions;
	public Sprite[] AbilityOptions;
	static public int P4CharIndex;
	static public int P4AbilityIndex;
	public int P4OptionIndex;



	public GameObject PlayerSelectBox;
	public GameObject PlayerAbilityBox;
	public GameObject P4OK;
	private GameObject Characterlist;


	// Use this for initialization
	void Start()
	{
		playerIndex = PlayerIndex.Four;
	}

	void FixedUpdate()
	{
		playerIndex = PlayerIndex.Four;
	}

	// Update is called once per frame
	void Update()
	{
		// Find a PlayerIndex, for a single player game
		// Will find the first controller that is connected ans use it
		if (!playerIndexSet || !prevState.IsConnected) 
		{
			for (int k = 0; k < 4; k++) 
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)k;
				GamePadState testState = GamePad.GetState (testPlayerIndex);
				if (testState.IsConnected) 
				{
					Debug.Log (string.Format ("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}

		prevState = state;
		state = GamePad.GetState (playerIndex);



		if (playerIndex == PlayerIndex.Four) 
		{

			for (int i = 0; i < CharOptions.Length; i++) 
			{
				if (i == P4CharIndex) 
				{
					P4part.sprite = CharOptions [i];
				}

				for (int p = 0; p < AbilityOptions.Length; p++) 
				{
					if (p == P4AbilityIndex) 
					{
						P4part2.sprite = AbilityOptions [p];
					}
				}

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P4OptionIndex == 0) 
			{

				if (P4CharIndex == 0) 
				{
                    FindObjectOfType<AudioManager>().Play("Duck");
                }

                if (P4CharIndex == 1) 
				{
                    FindObjectOfType<AudioManager>().Play("Duck");
                }

                if (P4CharIndex == 2) 
				{
                    FindObjectOfType<AudioManager>().Play("Unicorn");
                }

                if (P4CharIndex == 3) 
				{
                    FindObjectOfType<AudioManager>().Play("Hawk");
                }

            }


			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P4OptionIndex == 0)
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P4CharIndex < CharOptions.Length - 1) 
				{
					P4CharIndex++;
				} else 
				{
					P4CharIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P4OptionIndex == 0)
            {
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P4CharIndex >= 1)
				{
					P4CharIndex--;
				} else 
				{
					P4CharIndex = CharOptions.Length - 1;
				}

			}

			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P4OptionIndex == 1) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P4AbilityIndex < CharOptions.Length - 1) {
					P4AbilityIndex++;
				} else {
					P4AbilityIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P4OptionIndex == 1) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P4AbilityIndex >= 1) 
				{
					P4AbilityIndex--;
				} else 
				{
					P4AbilityIndex = AbilityOptions.Length - 1;
				}

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P4OptionIndex < TotalOptions) 
			{

				P4OptionIndex++;

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P4OptionIndex == 2) 
			{


                FindObjectOfType<AudioManager>().Play("Confirm");

            }


            if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P4OptionIndex < TotalOptions && P4CharIndex == 4) 
			{
				P4CharIndex = Random.Range (0, 4);


			}


			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed) 
			{

				P4OptionIndex--;

			}

			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && P4OptionIndex <= TotalOptions) {

				P4Ok = false;

			}


			if (P4OptionIndex == 0) {

				PlayerSelectBox.SetActive (true);
				PlayerAbilityBox.SetActive (false);

			}

			if (P4OptionIndex == 1) {

				PlayerAbilityBox.SetActive (true);
				PlayerSelectBox.SetActive (false);

			}

			if (P4OptionIndex == TotalOptions) {

				P4Ok = true;




			}

			if (P4OptionIndex == 2) 
			{

				P4OK.SetActive (true);

			} else 
			{

				P4OK.SetActive (false);

			}
		}
	}				
}