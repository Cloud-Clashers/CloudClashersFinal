using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using XInputDotNetPure;

public class PlayerSelectionP2 : MonoBehaviour 
{

	bool playerIndexSet = false;
	public PlayerIndex playerIndex = PlayerIndex.Two;
	GamePadState state;
	GamePadState prevState;
	static public bool P2Ok = false;
	public int TotalOptions = 2;


	//Player2
	public SpriteRenderer P2part;
	public SpriteRenderer P2part2;
	public Sprite[] CharOptions;
	public Sprite[] AbilityOptions;
	static public int P2CharIndex;
	static public int P2AbilityIndex;
	public int P2OptionIndex;



	public GameObject PlayerSelectBox;
	public GameObject PlayerAbilityBox;
	public GameObject P2OK;
	private GameObject Characterlist;


	// Use this for initialization
	void Start()
	{
		playerIndex = PlayerIndex.Two;
	}

	void FixedUpdate()
	{
		playerIndex = PlayerIndex.Two;
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



		if (playerIndex == PlayerIndex.Two) 
		{

			for (int i = 0; i < CharOptions.Length; i++) 
			{
				if (i == P2CharIndex) 
				{
					P2part.sprite = CharOptions [i];
				}

				for (int p = 0; p < AbilityOptions.Length; p++) 
				{
					if (p == P2AbilityIndex) 
					{
						P2part2.sprite = AbilityOptions [p];
					}
				}

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P2OptionIndex == 0) 
			{

				if (P2CharIndex == 0) 
				{
                    FindObjectOfType<AudioManager>().Play("Duck");

                }

                if (P2CharIndex == 1) 
				{
                    FindObjectOfType<AudioManager>().Play("Duck");

                }

                if (P2CharIndex == 2) 
				{
                    FindObjectOfType<AudioManager>().Play("Unicorn");

                }

                if (P2CharIndex == 3) 
				{
                    FindObjectOfType<AudioManager>().Play("Hawk");

                }

                if (P2CharIndex == 4)
                {
                    FindObjectOfType<AudioManager>().Play("Deer");

                }

            }


			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P2OptionIndex == 0)
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P2CharIndex < CharOptions.Length - 1) 
				{
					P2CharIndex++;
				} else 
				{
					P2CharIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P2OptionIndex == 0)
            {
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P2CharIndex >= 1)
				{
					P2CharIndex--;
				} else 
				{
					P2CharIndex = CharOptions.Length - 1;
				}

			}

			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P2OptionIndex == 1) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P2AbilityIndex < CharOptions.Length - 1) {
					P2AbilityIndex++;
				} else {
					P2AbilityIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P2OptionIndex == 1) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P2AbilityIndex >= 1) 
				{
					P2AbilityIndex--;
				} else 
				{
					P2AbilityIndex = AbilityOptions.Length - 1;
				}

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P2OptionIndex < TotalOptions || Input.GetKeyDown("z") ) 
			{

				P2OptionIndex++;

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P2OptionIndex == 2) 
			{


                FindObjectOfType<AudioManager>().Play("Confirm");

            }


            if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P2OptionIndex < TotalOptions && P2CharIndex == 5) 
			{
				P2CharIndex = Random.Range (0, 5);


			}


			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed) 
			{

				P2OptionIndex--;

			}

			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && P2OptionIndex <= TotalOptions) {

				P2Ok = false;

			}


			if (P2OptionIndex == 0) {

				PlayerSelectBox.SetActive (true);
				PlayerAbilityBox.SetActive (false);

			}

			if (P2OptionIndex == 1) {

				PlayerAbilityBox.SetActive (true);
				PlayerSelectBox.SetActive (false);

			}

			if (P2OptionIndex == TotalOptions) {

				P2Ok = true;




			}

			if (P2OptionIndex == 2) 
			{

				P2OK.SetActive (true);

			} else 
			{

				P2OK.SetActive (false);

			}
		}
	}				
}