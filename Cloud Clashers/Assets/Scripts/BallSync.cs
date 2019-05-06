using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSync : MonoBehaviour {

    public SpriteRenderer SRpart;
    //public Animator Apart;

    public int CharIndex;
    public int P1CharIndex;
    public int P1AnimIndex;


    private GameObject Balllist;
    public PlayerSelection P1Script;

    public Sprite[] BallOptions;
    public Animator[] AnimationOptions;

    int b = PlayerSelection.BallOption;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (b == PlayerSelection.BallOption)
        {

            SRpart.sprite = BallOptions[b];

            //Apart.SetLayerWeight(b, 1f);

        }



    }

}
