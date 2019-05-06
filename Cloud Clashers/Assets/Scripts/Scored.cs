using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scored : MonoBehaviour 
{
	private int pointstoadd = 1;



	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Ball" && gameObject.tag == "Goal2") 
		{

            

            ScoreManager.P1AddPoints (pointstoadd);

            FindObjectOfType<AudioManager>().Play("PlayerScore");

		}


		if (other.gameObject.tag == "Ball" && gameObject.tag == "Goal1") 
		{

			ScoreManager.P2AddPoints (pointstoadd);

            FindObjectOfType<AudioManager>().Play("PlayerScore");
        }


	}
}
