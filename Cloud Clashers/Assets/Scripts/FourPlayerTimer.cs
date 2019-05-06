using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FourPlayerTimer : MonoBehaviour {

    public float Overtimex = 500f;
    public float overtimey = -500f;
    public float startingtime = 5;
    public static float Timecounter;

    private TextMeshProUGUI theText;

    public GameObject Overtime;

    public GameObject Timerp1Round1Win;
    public GameObject Timerp1Round2Win;
    public GameObject Timerp2Round1Win;
    public GameObject Timerp2Round2Win;
    public GameObject Timerp3Round1Win;
    public GameObject Timerp3Round2Win;
    public GameObject Timerp4Round1Win;
    public GameObject Timerp4Round2Win;

    public GameObject P1WinAnimation;
    public GameObject P2WinAnimation;
    public GameObject P3WinAnimation;
    public GameObject P4WinAnimation;

    private ScoreManager scoremanager;
    private BallControl BallControl;
    private BallRespawn BallRespawn;
    //public GameObject ballcontroll;


    // Use this for initialization
    void Start()
    {
        theText = GetComponent<TextMeshProUGUI>();

        scoremanager = GetComponent<ScoreManager>();

        Timecounter = startingtime;

        BallControl = GetComponent<BallControl>();

        BallRespawn = GetComponent<BallRespawn>();

    }

    // Update is called once per frame
    void Update()
    {
        //var ballcontrollscript = ballcontroll.GetComponent<BallControl> ();

        int p1score = FourPlayerScoreManager.scoreP1;
        int p2score = FourPlayerScoreManager.scoreP2;
        int p3score = FourPlayerScoreManager.scoreP3;
        int p4score = FourPlayerScoreManager.scoreP4;

        Timecounter -= Time.deltaTime;

        theText.text = "" + Mathf.Round(Timecounter);

        Debug.Log("p1score is " + p1score);
        Debug.Log("p2score is " + p2score);

        //Player 1 win Conditions (Timer)
        if (Timecounter < 1 && FourPlayerScoreManager.P1win1 == false)
        {

            if (p1score > p2score && p1score > p3score && p1score > p4score && FourPlayerScoreManager.P1win1 == false)
            {

                Timerp1Round1Win.SetActive(true);

                FourPlayerScoreManager.scoreP1 = 5;

                FourPlayerScoreManager.scoreP2 = 5;

                FourPlayerScoreManager.scoreP3 = 5;

                FourPlayerScoreManager.scoreP4 = 5;

                FourPlayerScoreManager.P1win1 = true;

                BallControl.DestoryBall = true;

                BallRespawn.BallDestroyed = true;

                resetTime();

            }

        }

        if (Timecounter < 1 && FourPlayerScoreManager.P1win1 == true)
        {

            if (p1score > p2score && p1score > p3score && p1score > p4score && FourPlayerScoreManager.P1win1 == true)
            {

                FourPlayerScoreManager.P1win2 = true;

                BallControl.DestoryBall = true;

                P1WinAnimation.SetActive(true);

                StartCoroutine(WinTimer());

                resetTime();

            }
        }

        //Player 2 win Conditions (Timer)
        if (Timecounter < 1 && FourPlayerScoreManager.P2win1 == false)
        {

            if (p2score > p1score && p2score > p3score && p2score > p4score && FourPlayerScoreManager.P2win1 == false)
            {

                Timerp2Round1Win.SetActive(true);

                FourPlayerScoreManager.scoreP1 = 5;

                FourPlayerScoreManager.scoreP2 = 5;

                FourPlayerScoreManager.scoreP3 = 5;

                FourPlayerScoreManager.scoreP4 = 5;

                FourPlayerScoreManager.P2win1 = true;

                BallControl.DestoryBall = true;

                BallRespawn.BallDestroyed = true;

                resetTime();

            }

        }

        if (Timecounter < 1 && FourPlayerScoreManager.P2win1 == true)
        {

            if (p2score > p1score && p2score > p3score && p2score > p4score && FourPlayerScoreManager.P2win1 == true)
            {

                FourPlayerScoreManager.P2win2 = true;

                BallControl.DestoryBall = true;

                P2WinAnimation.SetActive(true);

                StartCoroutine(WinTimer());

                resetTime();

            }
        }

        //Player 3 win Conditions (Timer)
        if (Timecounter < 1 && FourPlayerScoreManager.P3win1 == false)
        {

            if (p3score > p1score && p3score > p2score && p3score > p4score && FourPlayerScoreManager.P3win1 == false)
            {

                Timerp3Round1Win.SetActive(true);

                FourPlayerScoreManager.scoreP1 = 5;

                FourPlayerScoreManager.scoreP2 = 5;

                FourPlayerScoreManager.scoreP3 = 5;

                FourPlayerScoreManager.scoreP4 = 5;

                FourPlayerScoreManager.P3win1 = true;

                BallControl.DestoryBall = true;

                BallRespawn.BallDestroyed = true;

                resetTime();

            }

        }

        if (Timecounter < 1 && FourPlayerScoreManager.P3win1 == true)
        {

            if (p3score > p1score && p3score > p2score && p3score > p4score && FourPlayerScoreManager.P2win1 == true)
            {

                FourPlayerScoreManager.P3win2 = true;

                BallControl.DestoryBall = true;

                P3WinAnimation.SetActive(true);

                StartCoroutine(WinTimer());

                resetTime();

            }
        }

        //Player 4 win Conditions (Timer)
        if (Timecounter < 1 && FourPlayerScoreManager.P4win1 == false)
        {

            if (p4score > p1score && p4score > p2score && p4score > p3score && FourPlayerScoreManager.P4win1 == false)
            {

                Timerp4Round1Win.SetActive(true);

                FourPlayerScoreManager.scoreP1 = 5;

                FourPlayerScoreManager.scoreP2 = 5;

                FourPlayerScoreManager.scoreP3 = 5;

                FourPlayerScoreManager.scoreP4 = 5;

                FourPlayerScoreManager.P4win1 = true;

                BallControl.DestoryBall = true;

                BallRespawn.BallDestroyed = true;

                resetTime();

            }

        }

        if (Timecounter < 1 && FourPlayerScoreManager.P4win1 == true)
        {

            if (p4score > p1score && p4score > p2score && p4score > p3score && FourPlayerScoreManager.P4win1 == true)
            {

                FourPlayerScoreManager.P4win2 = true;

                BallControl.DestoryBall = true;

                P4WinAnimation.SetActive(true);

                StartCoroutine(WinTimer());

                resetTime();

            }
        }

        if (p1score != p2score)
        {
            Overtime.SetActive(false);
        }

        if (Timecounter < 1)
        {
            if (p2score == p1score && p2score == p3score && p2score == p4score)
            {

                Overtime.SetActive(true);
                theText.text = "   ";

            }
        }

 



    }

    private IEnumerator WinTimer()
    {

        yield return new WaitForSecondsRealtime(5);

        SceneManager.LoadScene("Main Menu");

    }

    public void resetTime()
    {

        Timecounter = startingtime;

    }
}
