using UnityEngine;
using System.Collections;

public class P2Warp : MonoBehaviour
{

    public Transform warpTarget;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player2")
        {

            other.gameObject.transform.position = warpTarget.position;

        }

    }
}

