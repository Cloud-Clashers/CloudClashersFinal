using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2CharacterSync : MonoBehaviour 
{

	public SpriteRenderer SRP2part;
	public Animator AP2part;

	public int CharIndex;
	public int P1CharIndex;
	public int P1AnimIndex;

	private GameObject Characterlist;
	public PlayerSelection P2Script;

	public Sprite[] p2CharacterOptions;
	public Animator[] p2AnimationOptions;

	int p2 = PlayerSelectionP2.P2CharIndex;




	// Use this for initialization
	void Start () 
	{



	}

	// Update is called once per frame
	void Update () 
	{

		if (p2 == PlayerSelectionP2.P2CharIndex) 
		{

			SRP2part.sprite = p2CharacterOptions [p2];

			AP2part.SetLayerWeight (p2, 1f);

		}



	}

}
