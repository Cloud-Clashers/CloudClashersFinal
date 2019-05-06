using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour {

	public static int scoreP1;

	public static int scoreP2;

	private TextMeshProUGUI theText;

    public int WinScore = 5;


	static public bool P1win1 = false;
	static public bool P1win2 = false;
	static public bool P2win1 = false;
	static public bool P2win2 = false;

	public GameObject P1Round1Win;
	public GameObject P1Round2Win;
	public GameObject P2Round1Win;
	public GameObject P2Round2Win;

    public GameObject P1WinAnimation;
    public GameObject P2WinAnimation;

    float time = Timer.Timecounter;


	// Use this for initialization
	void Start () 
	{

		theText = GetComponent<TextMeshProUGUI> ();


		scoreP1 = 0;

		scoreP2 = 0;


		P1win1 = false;
	 	P1win2 = false;
		P2win1 = false;
		P2win2 = false;


	}

	// Update is called once per frame
	void Update () 
	{

		theText.text = "P1: " + scoreP1 + " P2: " + scoreP2 ;

		if (scoreP1 == WinScore && P1win1 == false) 
		{
			Debug.Log ("Player 1 Wins");

			P1win1 = true;

			scoreP1 = 0;

			scoreP2 = 0;

            Timer.Timecounter = 60;

			P1Round1Win.SetActive (true);
		}

		if (scoreP1 == WinScore && P1win1 == true) 
		{
			Debug.Log ("Player 1 Wins");

			P1Round2Win.SetActive (true);

            P1WinAnimation.SetActive(true);

            StartCoroutine(WinTimer());

		}



		if (scoreP2 == WinScore && P2win1 == false) 
		{
			Debug.Log ("Player 2 Wins");

			P2win1 = true;

			scoreP1 = 0;

			scoreP2 = 0;

            Timer.Timecounter = 60;

            P2Round1Win.SetActive (true);
		}

		if (scoreP2 == WinScore && P2win1 == true) 
		{
			Debug.Log ("Player 2 Wins");

            P2Round2Win.SetActive (true);

            P2WinAnimation.SetActive(true);

            StartCoroutine(WinTimer());
		}
			


	}

    private IEnumerator WinTimer()
    {
        //FindObjectOfType<AudioManager>().Play("Victory");

        PlayerSelection.P1Ok = false;
        PlayerSelectionP2.P2Ok = false;

        FindObjectOfType<AudioManager>().Stop("Theme");

        yield return new WaitForSecondsRealtime(5.0f);

        FindObjectOfType<AudioManager>().Play("MainMenuTheme");

        SceneManager.LoadScene("Main Menu");



    }


    public static void P1AddPoints (int pointsToAdd)
	{
		scoreP1 += pointsToAdd;
	}

	public static void P2AddPoints (int pointsToAdd)
	{
		scoreP2 += pointsToAdd;
	}

    public static void P3AddPoints(int pointsToAdd)
    {
        scoreP2 += pointsToAdd;
    }

    public static void P4AddPoints(int pointsToAdd)
    {
        scoreP2 += pointsToAdd;
    }
}
