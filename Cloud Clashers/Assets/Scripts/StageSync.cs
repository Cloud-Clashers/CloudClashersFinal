using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSync : MonoBehaviour {

    public SpriteRenderer SRpart;
    public Animator Apart;

    //public int CharIndex;
    //public int P1CharIndex;
    //public int P1AnimIndex;

    private GameObject Characterlist;
    public StageSelect StageSelect;

    public Sprite[] StageSelectOptions;
    public Animator[] StageAnimationOptions;

    int S = StageSelect.index;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (S == StageSelect.index)
        {

            SRpart.sprite = StageSelectOptions[S];

            Apart.SetLayerWeight(S, 1f);
        }



    }
}
