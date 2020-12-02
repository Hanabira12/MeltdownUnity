using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Time left in the timer
    public float timeRemaining = 10;
   // public bool isRunning = false;

    private void Start()
    {
        // start timer
        //   isRunning = true;
        StartCoroutine(LoadGameOverAfterTimer());
    }

    // Update is called once per frame
    void Update()
    {/*
 //       if (isRunning = true)
 //       {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
            //              timeRemaining = 0;
            //              isRunning = false;
            SceneManager.LoadScene("GameOver");
        }
 //       }*/
    }

    IEnumerator LoadGameOverAfterTimer()
    {
        yield return new WaitForSeconds(timeRemaining);
        SceneManager.LoadScene("GameOver");
    }
}
