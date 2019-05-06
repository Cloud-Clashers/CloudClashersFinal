using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4CaracterSync : MonoBehaviour
{

    public SpriteRenderer SRP4part;
    public Animator AP4part;

    public int CharIndex;
    public int P4CharIndex;
    public int P4AnimIndex;

    private GameObject Characterlist;
    public PlayerSelection P4Script;

    public Sprite[] p4CharacterOptions;
    public Animator[] p4AnimationOptions;

    int p4 = PlayerSelectionP4.P4CharIndex;




    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (p4 == PlayerSelectionP4.P4CharIndex)
        {

            SRP4part.sprite = p4CharacterOptions[p4];

            AP4part.SetLayerWeight(p4, 1f);

        }



    }

}
