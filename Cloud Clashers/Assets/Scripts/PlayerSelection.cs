using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using XInputDotNetPure;

public class PlayerSelection : MonoBehaviour 
{


	bool playerIndexSet = false;
	public PlayerIndex playerIndex = PlayerIndex.One;
	GamePadState state;
	GamePadState prevState;
	static public bool P1Ok = false;
	public int TotalOptions = 2;


	//Player1
	public SpriteRenderer part;
	public SpriteRenderer part2;
	public SpriteRenderer part3;
	public Sprite[] CharOptions;
	public Sprite[] AbilityOptions;
	public Sprite[] BallOptions;
	static public int P1CharIndex;
	static public int P1AbilityIndex;
	static public int BallOption;
	public int P1OptionIndex;



	public GameObject PlayerSelectBox;
	public GameObject PlayerAbilityBox;
	public GameObject BallBox;
	public GameObject P1OK;
	private GameObject Characterlist;


	// Use this for initialization
	void Start()
	{

        playerIndex = PlayerIndex.One;
    }

	void FixedUpdate()
	{
		playerIndex = PlayerIndex.One;
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


		if (playerIndex == PlayerIndex.One) 
		{

			for (int i = 0; i < CharOptions.Length; i++) 
			{
				if (i == P1CharIndex) 
				{
					part.sprite = CharOptions [i];
				}

				for (int p = 0; p < AbilityOptions.Length; p++) 
				{
					if (p == P1AbilityIndex) 
					{
						part2.sprite = AbilityOptions [p];
					}
				}

                for (int b = 0; b < BallOptions.Length; b++)
                {
                    if (b == BallOption)
                    {
                        part3.sprite = BallOptions[b];
                    }
                }

			}
				
			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P1OptionIndex == 0) 
			{

				if (P1CharIndex == 0) 
				{
                    FindObjectOfType<AudioManager>().Play("Duck");

                }

                if (P1CharIndex == 1) 
				{
                    FindObjectOfType<AudioManager>().Play("Duck");

                }

                if (P1CharIndex == 2) 
				{
                    FindObjectOfType<AudioManager>().Play("Unicorn");

                }

                if (P1CharIndex == 3) 
				{
                    FindObjectOfType<AudioManager>().Play("Hawk");

                }

                if (P1CharIndex == 4)
                {
                    FindObjectOfType<AudioManager>().Play("Deer");

                }

            }


			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P1OptionIndex == 0)
			{
                FindObjectOfType<AudioManager>().Play("Navigate");


                if (P1CharIndex < CharOptions.Length - 1) 
				{
					P1CharIndex++;
				} else 
				{
					P1CharIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P1OptionIndex == 0)
            {

                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P1CharIndex >= 1)
				{
					P1CharIndex--;
				} else 
				{
					P1CharIndex = CharOptions.Length - 1;
				}

			}

			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P1OptionIndex == 1) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P1AbilityIndex < CharOptions.Length - 1) {
					P1AbilityIndex++;
				} else {
					P1AbilityIndex = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P1OptionIndex == 1) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (P1AbilityIndex >= 1) 
				{
					P1AbilityIndex--;
				} else 
				{
					P1AbilityIndex = AbilityOptions.Length - 1;
				}

			}

			if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed && P1OptionIndex == 2) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (BallOption < CharOptions.Length - 1) {
					BallOption++;
				} else {
					BallOption = 0;
				}

			}

			if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed && P1OptionIndex == 2) 
			{
                FindObjectOfType<AudioManager>().Play("Navigate");

                if (BallOption >= 1) 
				{
					BallOption--;
				} else 
				{
					BallOption = BallOptions.Length - 1;
				}

			}


			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P1OptionIndex < TotalOptions) 
			{

				P1OptionIndex++;

			}

			if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P1OptionIndex == 3) 
			{


                FindObjectOfType<AudioManager>().Play("Confirm");


            }


            if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && P1OptionIndex < TotalOptions && P1CharIndex == 5) 
			{
				P1CharIndex = Random.Range (0, 5);


			}


			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed) 
			{

				P1OptionIndex--;

			}

			if (prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && P1OptionIndex <= TotalOptions) {

				P1Ok = false;

			}


			if (P1OptionIndex == 0) {

				PlayerSelectBox.SetActive (true);
				PlayerAbilityBox.SetActive (false);
				BallBox.SetActive (false);

			}

			if (P1OptionIndex == 1) {

				PlayerAbilityBox.SetActive (true);
				PlayerSelectBox.SetActive (false);
				BallBox.SetActive (false);

			}

			if (P1OptionIndex == 2) {

				PlayerAbilityBox.SetActive (false);
				PlayerSelectBox.SetActive (false);
				BallBox.SetActive (true);

			}

			if (P1OptionIndex == TotalOptions) {

				P1Ok = true;




			}

			if (P1OptionIndex > 2) 
			{

				P1OK.SetActive (true);

			} else 
			{

				P1OK.SetActive (false);

			}
		}
	}				
}