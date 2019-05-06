using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSync : MonoBehaviour 
{
	public SpriteRenderer SRpart;
	public Animator Apart;

	public int CharIndex;
	public int P1CharIndex;
	public int P1AnimIndex;


	private GameObject Characterlist;
	public PlayerSelection P1Script;

	public Sprite[] CharacterOptions;
	public Animator[] AnimationOptions;

	int p = PlayerSelection.P1CharIndex;




	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (p == PlayerSelection.P1CharIndex) 
		{

			SRpart.sprite = CharacterOptions [p];

			Apart.SetLayerWeight (p, 1f);

		}
			
			
		
	}


}
