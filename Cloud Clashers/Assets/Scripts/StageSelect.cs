using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
using TMPro;

public class StageSelect : MonoBehaviour
{

    static public int index = 0;
    public int totalLevels = 2;

    private TextMeshProUGUI theText;

    public GameObject GrassStageOn;
    public GameObject GrassStageOff;
    public GameObject SnowyStageOn;
    public GameObject SnowStageOff;


    public GameObject SnowStageName;
    public GameObject GrassStageName;

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    void Start()
    {

        theText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
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

            GrassStageOn.SetActive(true);
            GrassStageOff.SetActive(false);
            SnowyStageOn.SetActive(false);
            SnowStageOff.SetActive(true);

            GrassStageName.SetActive(true);
            SnowStageName.SetActive(false);

        }

        if (index == 1)
        {

            GrassStageOn.SetActive(false);
            GrassStageOff.SetActive(true);
            SnowyStageOn.SetActive(true);
            SnowStageOff.SetActive(false);

            GrassStageName.SetActive(false);
            SnowStageName.SetActive(true);

        }



        if (Input.GetKeyDown(KeyCode.RightArrow) || prevState.DPad.Right == ButtonState.Pressed && state.DPad.Right == ButtonState.Released)
        {
            FindObjectOfType<AudioManager>().Play("Navigate");



            if (index < totalLevels - 1)
            {
                index++;
                Vector2 Position = transform.position;
                transform.position = Position;
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || prevState.DPad.Left == ButtonState.Pressed && state.DPad.Left == ButtonState.Released)
        {
            FindObjectOfType<AudioManager>().Play("Navigate");

            if (index > 0)
            {
                index--;
                Vector2 Position = transform.position;
                transform.position = Position;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("P1A"))
        {

            FindObjectOfType<AudioManager>().Play("Select");

            if (index == 0)
            {
				FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
                SceneManager.LoadScene("Game");


            }

            if (index == 1)
            {

				FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
                SceneManager.LoadScene("Game");

            }


        }



    }

}

