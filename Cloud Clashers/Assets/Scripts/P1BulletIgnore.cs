using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1BulletIgnore : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{

		Physics2D.IgnoreLayerCollision (10, 11);

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
