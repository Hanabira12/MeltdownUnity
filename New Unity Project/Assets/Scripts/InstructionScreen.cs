using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionScreen : MonoBehaviour
{
    public Text timeText;
    public float timeRemaining = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0.01)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            DisplayTime(timeRemaining);
            LoadGame();
        }
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Scene_0");
    }

    void DisplayTime(float timeToDisplay)
    {
        timeText.text = string.Format("{0:0}", timeToDisplay);
    }
}
