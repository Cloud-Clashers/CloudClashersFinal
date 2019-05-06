using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour 
{
	public float xspeed = 0f;
	public float yspeed = 0f;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (DestroyBullet ());

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Get the bullets current position
		Vector2 position = transform.position;

		//compute the bullet's new position
		//position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
		position.x += xspeed;
		position.y += yspeed;
			
		//Update the bullet's position
		transform.position = position;

	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (gameObject.tag == "Bullet" && other.gameObject.name == "Barriers") 
		{

			Destroy (gameObject);

		}

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

        if (other.gameObject.tag == "Shield")
        {
            Debug.Log("Reflect");

            xspeed = xspeed * -1;

            //Destroy(gameObject);


        }

    }


	IEnumerator DestroyBullet()
	{
		yield return new WaitForSeconds (5f);
		Destroy (gameObject);
	}
}
