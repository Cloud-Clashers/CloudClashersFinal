using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using XInputDotNetPure;

public class PlayerSelectionP3 : MonoBehaviour 
{

	bool playerIndexSet = false;
	public PlayerIndex playerIndex = PlayerIndex.Three;
	GamePadState state;
	GamePadState prevState;
	static public bool P3Ok = false;
	public int TotalOptions = 2;


	//Player1
	public SpriteRenderer P3part;
	public SpriteRenderer P3part2;
	public Sprite[] CharOptions;
	public Sprite[] AbilityOptions;
	static public int P3CharIndex;
	static public int P3AbilityIndex;
	public int P3OptionIndex;



	public GameObject PlayerSelectBox;
	public GameObject PlayerAbilityBox;
	public GameObject P3OK;
	private GameObject Characterlist;


	// Use this for initialization
	void Start()
	{
		playerIndex = PlayerIndex.Three;
	}

	void FixedUpdate()
	{
		playerIndex = PlayerIndex.Three;
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



		if (playerIndex == PlayerIndex.Three) 
		{

			for (int i = 0; i < CharOptions.Length; i++) 
			{
				if (i == P3CharIndex) 
				{
					P3part.sprite = CharOptions [i];
				}

				for (int p = 0; p < AbilityOptions.Length; p++) 
				{
					if (p == P3AbilityIndex) 
					{
						P3part2.sprite = AbilityOptions [p];
					}
				}

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P3OptionIndex == 0) 
			{

				if (P3CharIndex == 0) 
				{
                    FindObjectOfType<AudioManager>().Play("Duck");
                }

                if (P3CharIndex == 1) 
				{
                    FindObjectOfType<AudioManager>().Play("Duck");
                }

                if (P3CharIndex == 2) 
				{
                    FindObjectOfType<AudioManager>().Play("Unicorn");
                }

                if (P3CharIndex == 3) 
				{
                    FindObjectOfType<AudioManager>().Play("Hawk");
                }

            }


			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P3OptionIndex == 0)
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P3CharIndex < CharOptions.Length - 1) 
				{
					P3CharIndex++;
				} else 
				{
					P3CharIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P3OptionIndex == 0)
            {
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P3CharIndex >= 1)
				{
					P3CharIndex--;
				} else 
				{
					P3CharIndex = CharOptions.Length - 1;
				}

			}

			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P3OptionIndex == 1) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P3AbilityIndex < CharOptions.Length - 1) {
					P3AbilityIndex++;
				} else {
					P3AbilityIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P3OptionIndex == 1) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P3AbilityIndex >= 1) 
				{
					P3AbilityIndex--;
				} else 
				{
					P3AbilityIndex = AbilityOptions.Length - 1;
				}

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P3OptionIndex < TotalOptions) 
			{

				P3OptionIndex++;

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P3OptionIndex == 2) 
			{


                FindObjectOfType<AudioManager>().Play("Confirm");

            }


            if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P3OptionIndex < TotalOptions && P3CharIndex == 4) 
			{
				P3CharIndex = Random.Range (0, 4);


			}


			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed) 
			{

				P3OptionIndex--;

			}

			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && P3OptionIndex <= TotalOptions) {

				P3Ok = false;

			}


			if (P3OptionIndex == 0) {

				PlayerSelectBox.SetActive (true);
				PlayerAbilityBox.SetActive (false);

			}

			if (P3OptionIndex == 1) {

				PlayerAbilityBox.SetActive (true);
				PlayerSelectBox.SetActive (false);

			}

			if (P3OptionIndex == TotalOptions) {

				P3Ok = true;




			}

			if (P3OptionIndex == 2) 
			{

				P3OK.SetActive (true);

			} else 
			{

				P3OK.SetActive (false);

			}
		}
	}				
}