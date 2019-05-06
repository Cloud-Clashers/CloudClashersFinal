using UnityEngine;
using System.Collections;

public class P1Warp : MonoBehaviour
{

    public Transform warpTarget;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player1")
        {

            other.gameObject.transform.position = warpTarget.position;

        }

    }
}
