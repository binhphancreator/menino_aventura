using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager3 : MonoBehaviour
{
    
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    UI3Manager ui3;
    bool isGameover;
    Game3Controller gc;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        ui3 = FindObjectOfType<UI3Manager>();
        gc = FindObjectOfType<Game3Controller>();
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
                ui3.ShowGameOverPanel(true);
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
