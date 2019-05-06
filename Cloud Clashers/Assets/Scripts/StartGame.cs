using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public GameObject Ball;
    public GameObject Spawn;
    public GameObject CountDown;

    // Use this for initialization
    void Start()
    {


        StartCoroutine(spawn());

    }

    // Update is called once per frame
    void Update()
    {



    }

    private IEnumerator spawn()
    {

        Time.timeScale = 0;
        float PauseTime = Time.realtimeSinceStartup + 4f;
        while (Time.realtimeSinceStartup < PauseTime)
            yield return 0;
        FindObjectOfType<AudioManager>().Play("Theme");
        CountDown.gameObject.SetActive(false);
        Time.timeScale = 1;



        //yield return new WaitForSecondsRealtime(5.0f);

        Instantiate(Ball, Spawn.transform.position, Spawn.transform.rotation);

    }
}
