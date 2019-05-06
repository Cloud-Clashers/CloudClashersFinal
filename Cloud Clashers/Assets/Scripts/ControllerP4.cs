using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class ControllerP4 : MonoBehaviour {

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public float P4Speed = 600;

    public float P4savedSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int k = 0; k < 4; k++)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)k;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                    Debug.Log("Player One Index is: " + playerIndex);
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);

        playerIndex = PlayerIndex.Four;


        if (playerIndex == PlayerIndex.Four)
        {

            float moveHorizontal = state.ThumbSticks.Left.X * P4Speed * Time.deltaTime;
            float moveVertical = 0;

            this.transform.Translate(new Vector3(moveHorizontal, moveVertical, 0f));

        }

    }
}
