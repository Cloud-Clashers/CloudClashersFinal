using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour 
{

	public GameObject Ball;
	public GameObject Respawn;
    public GameObject RespawnParticle;

    public static bool OvertimeActive;
    public static bool BallDestroyed = false;

    // Use this for initialization
    void Start () 
	{


		
	}
	
	// Update is called once per frame
	void Update () 
	{
       
        if (BallDestroyed == true)
            {

                StartCoroutine(spawn());


                BallDestroyed = false;

            }

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ball" && Timer.Timecounter > 0) 
		{
            StartCoroutine(spawn());


			StartCoroutine (Goal());


		}
	}

	private IEnumerator Goal()
	{
        //Instantiate(RespawnParticle, Respawn.transform.position, Respawn.transform.rotation);

        yield return new WaitForSecondsRealtime(3);

        Instantiate (Ball, Respawn.transform.position, Respawn.transform.rotation);

	}

    private IEnumerator spawn()
    {

        yield return new WaitForSecondsRealtime(1);

        Instantiate(RespawnParticle, Respawn.transform.position, Respawn.transform.rotation);

        FindObjectOfType<AudioManager>().Play("Respawn");

    }

}
