using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3CharacterSync : MonoBehaviour
{

    public SpriteRenderer SRP3part;
    public Animator AP3part;

    public int CharIndex;
    public int P3CharIndex;
    public int P3AnimIndex;

    private GameObject Characterlist;
    public PlayerSelection P3Script;

    public Sprite[] p3CharacterOptions;
    public Animator[] p3AnimationOptions;

    int p3 = PlayerSelectionP3.P3CharIndex;




    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (p3 == PlayerSelectionP3.P3CharIndex)
        {

            SRP3part.sprite = p3CharacterOptions[p3];

            AP3part.SetLayerWeight(p3, 1f);

        }



    }

}
