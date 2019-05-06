using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourPlayerScored : MonoBehaviour
{

    private int pointstosubtract = 1;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ball" && gameObject.tag == "Goal1")
        {

            FourPlayerScoreManager.P1subtractPoints(pointstosubtract);

        }


        if (other.gameObject.tag == "Ball" && gameObject.tag == "Goal2")
        {

            FourPlayerScoreManager.P2subtractPoints(pointstosubtract);
        }

        if (other.gameObject.tag == "Ball" && gameObject.tag == "Goal3")
        {

            FourPlayerScoreManager.P3subtractPoints(pointstosubtract);
        }

        if (other.gameObject.tag == "Ball" && gameObject.tag == "Goal4")
        {

            FourPlayerScoreManager.P4subtractPoints(pointstosubtract);
        }

    }

}
