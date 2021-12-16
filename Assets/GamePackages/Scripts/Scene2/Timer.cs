using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    UI2Manager ui2;
    bool isGameover;
    Game2Controller gc;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        ui2 = FindObjectOfType<UI2Manager>();
        gc = FindObjectOfType<Game2Controller>();
    }

    void Update()
    {
        if(gc.IsGameOver()) return;
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                Cursor.lockState = CursorLockMode.None;
                ui2.ShowGameOverPanel(true);
                gc.SetGameOverState(true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
