using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2BulletIgnore : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{

		Physics2D.IgnoreLayerCollision (12, 13);

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
