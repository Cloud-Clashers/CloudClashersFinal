using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FourPlayerScoreManager : MonoBehaviour
{

    public static int scoreP1;
    public static int scoreP2;
    public static int scoreP3;
    public static int scoreP4;


    public Text text;


    static public bool P1win1 = false;
    static public bool P1win2 = false;
    static public bool P2win1 = false;
    static public bool P2win2 = false;
    static public bool P3win1 = false;
    static public bool P3win2 = false;
    static public bool P4win1 = false;
    static public bool P4win2 = false;


    public bool P1Active = true;
    public bool P2Active = true;
    public bool P3Active = true;
    public bool P4Active = true;

    public GameObject P1Round1Win;
    public GameObject P1Round2Win;
    public GameObject P2Round1Win;
    public GameObject P2Round2Win;
    public GameObject P3Round1Win;
    public GameObject P3Round2Win;
    public GameObject P4Round1Win;
    public GameObject P4Round2Win;

    public GameObject P1Loss;
    public GameObject P2Loss;
    public GameObject P3Loss;
    public GameObject P4Loss;

    public GameObject P1WinAnimation;
    public GameObject P2WinAnimation;
    public GameObject P3WinAnimation;
    public GameObject P4WinAnimation;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    float time = Timer.Timecounter;


    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();


        scoreP1 = 5;
        scoreP2 = 5;
        scoreP3 = 5;
        scoreP4 = 5;


        P1win1 = false;
        P1win2 = false;
        P2win1 = false;
        P2win2 = false;
        P3win1 = false;
        P3win2 = false;
        P4win1 = false;
        P4win2 = false;

        P1Loss.SetActive(false);
        P2Loss.SetActive(false);
        P3Loss.SetActive(false);
        P4Loss.SetActive(false);


        Player1.SetActive(true);
        Player2.SetActive(true);
        Player3.SetActive(true);
        Player4.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        text.text = "P1: " + scoreP1 + " P2: " + scoreP2 + " P3: " + scoreP3  + " P4: " + scoreP4;

        if (scoreP1 == 0)
        {

            P1Active = false;
            P1Loss.SetActive(true);
            Player1.SetActive(false);

        }

        if (scoreP2 == 0)
        {

            P2Active = false;
            P2Loss.SetActive(true);
            Player2.SetActive(false);

        }

        if (scoreP3 == 0)
        {

            P3Active = false;
            P3Loss.SetActive(true);
            Player3.SetActive(false);

        }

        if (scoreP4 == 0)
        {

            P4Active = false;
            P4Loss.SetActive(true);
            Player4.SetActive(false);

        }

        //P1 Win Conditions
        if ( P1Active == true && P2Active == false && P3Active == false && P4Active == false && P1win1 == false)
        {
            Debug.Log("Player 1 Wins");

            P1win1 = true;

            scoreP1 = 5;
            scoreP2 = 5;
            scoreP3 = 5;
            scoreP4 = 5;

            P1Active = true;
            P2Active = true;
            P3Active = true;
            P4Active = true;

            Timer.Timecounter = 60;

            Player1.SetActive(true);
            Player2.SetActive(true);
            Player3.SetActive(true);
            Player4.SetActive(true);

            P1Loss.SetActive(false);
            P2Loss.SetActive(false);
            P3Loss.SetActive(false);
            P4Loss.SetActive(false);

            P1Round1Win.SetActive(true);
        }

        if (P1Active == true && P2Active == false && P3Active == false && P4Active == false && P1win1 == true)
        {
            Debug.Log("Player 1 Wins");

            scoreP1 = 5;
            scoreP2 = 5;
            scoreP3 = 5;
            scoreP4 = 5;

            P1Active = true;
            P2Active = true;
            P3Active = true;
            P4Active = true;

            Timer.Timecounter = 60;

            Player1.SetActive(true);
            Player2.SetActive(true);
            Player3.SetActive(true);
            Player4.SetActive(true);

            P1Loss.SetActive(false);
            P2Loss.SetActive(false);
            P3Loss.SetActive(false);
            P4Loss.SetActive(false);

            P1Round2Win.SetActive(true);

            P1WinAnimation.SetActive(true);

            StartCoroutine(WinTimer());

            SceneManager.LoadScene("Main Menu");
        }

        //P2 Win Conditions
        if (P1Active == false && P2Active == true && P3Active == false && P4Active == false && P2win1 == false)
        {
            Debug.Log("Player 2 Wins");

            P2win1 = true;

            scoreP1 = 5;
            scoreP2 = 5;
            scoreP3 = 5;
            scoreP4 = 5;

            P1Active = true;
            P2Active = true;
            P3Active = true;
            P4Active = true;

            Timer.Timecounter = 60;

            Player1.SetActive(true);
            Player2.SetActive(true);
            Player3.SetActive(true);
            Player4.SetActive(true);

            P1Loss.SetActive(false);
            P2Loss.SetActive(false);
            P3Loss.SetActive(false);
            P4Loss.SetActive(false);

            P2Round1Win.SetActive(true);
        }

        if (P1Active == false && P2Active == true && P3Active == false && P4Active == false && P2win1 == true)
        {
            Debug.Log("Player 2 Wins");

            scoreP1 = 5;
            scoreP2 = 5;
            scoreP3 = 5;
            scoreP4 = 5;

            P1Active = true;
            P2Active = true;
            P3Active = true;
            P4Active = true;

            Timer.Timecounter = 60;

            Player1.SetActive(true);
            Player2.SetActive(true);
            Player3.SetActive(true);
            Player4.SetActive(true);

            P1Loss.SetActive(false);
            P2Loss.SetActive(false);
            P3Loss.SetActive(false);
            P4Loss.SetActive(false);

            P2Round2Win.SetActive(true);

            P2WinAnimation.SetActive(true);

            StartCoroutine(WinTimer());

            SceneManager.LoadScene("Main Menu");
        }

        //P3 Win Conditions
        if (P1Active == false && P2Active == false && P3Active == true && P4Active == false && P3win1 == false)
        {
            Debug.Log("Player 3 Wins");

            P3win1 = true;

            scoreP1 = 5;
            scoreP2 = 5;
            scoreP3 = 5;
            scoreP4 = 5;

            P1Active = true;
            P2Active = true;
            P3Active = true;
            P4Active = true;

            Timer.Timecounter = 60;

            Player1.SetActive(true);
            Player2.SetActive(true);
            Player3.SetActive(true);
            Player4.SetActive(true);

            P1Loss.SetActive(false);
            P2Loss.SetActive(false);
            P3Loss.SetActive(false);
            P4Loss.SetActive(false);

            P3Round1Win.SetActive(true);
        }

        if (P1Active == false && P2Active == false && P3Active == true && P4Active == false && P3win1 == true)
        {
            Debug.Log("Player 3 Wins");

            scoreP1 = 5;
            scoreP2 = 5;
            scoreP3 = 5;
            scoreP4 = 5;

            P1Active = true;
            P2Active = true;
            P3Active = true;
            P4Active = true;

            Timer.Timecounter = 60;

            Player1.SetActive(true);
            Player2.SetActive(true);
            Player3.SetActive(true);
            Player4.SetActive(true);

            P1Loss.SetActive(false);
            P2Loss.SetActive(false);
            P3Loss.SetActive(false);
            P4Loss.SetActive(false);

            P3Round2Win.SetActive(true);

            P2WinAnimation.SetActive(true);

            StartCoroutine(WinTimer());

            SceneManager.LoadScene("Main Menu");
        }

        //P4 Win Conditions
        if (P1Active == false && P2Active == false && P3Active == false && P4Active == true && P4win1 == false)
        {
            Debug.Log("Player 4 Wins");

            P4win1 = true;

            scoreP1 = 5;
            scoreP2 = 5;
            scoreP3 = 5;
            scoreP4 = 5;

            P1Active = true;
            P2Active = true;
            P3Active = true;
            P4Active = true;

            Timer.Timecounter = 60;

            P1Loss.SetActive(false);
            P2Loss.SetActive(false);
            P3Loss.SetActive(false);
            P4Loss.SetActive(false);

            P4Round1Win.SetActive(true);
        }

        if (P1Active == false && P2Active == false && P3Active == false && P4Active == true && P4win1 == true)
        {
            Debug.Log("Player 4 Wins");

            scoreP1 = 5;
            scoreP2 = 5;
            scoreP3 = 5;
            scoreP4 = 5;

            P1Active = true;
            P2Active = true;
            P3Active = true;
            P4Active = true;

            Timer.Timecounter = 60;

            P1Loss.SetActive(false);
            P2Loss.SetActive(false);
            P3Loss.SetActive(false);
            P4Loss.SetActive(false);

            P4Round2Win.SetActive(true);

            P4WinAnimation.SetActive(true);

            StartCoroutine(WinTimer());

            SceneManager.LoadScene("Main Menu");
        }



    }

    private IEnumerator WinTimer()
    {

        yield return new WaitForSecondsRealtime(5);

        SceneManager.LoadScene("Main Menu");



    }


    public static void P1subtractPoints(int pointstosubtract)
    {
        scoreP1 -= pointstosubtract;
    }

    public static void P2subtractPoints(int pointstosubtract)
    {
        scoreP2 -= pointstosubtract;
    }

    public static void P3subtractPoints(int pointstosubtract)
    {
        scoreP3 -= pointstosubtract;
    }

    public static void P4subtractPoints(int pointstosubtract)
    {
        scoreP4 -= pointstosubtract;
    }

}
