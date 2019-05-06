using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player1")
        {
            Debug.Log("Stunned");

            ControllerP1.Stun = true;
            Destroy(gameObject);


        }

        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("Stunned");

            ControllerP2.Stun = true;
            Destroy(gameObject);


        }

    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
