using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public string replayScene;
    public bool isGameOver;
    public bool checkTime = true;
    public bool timerIsRunning = false;
    public float timeRemaining = 180;
    public Text timeText,scoreText;
    float timeTotal;
    float scoreTime;
    public AudioSource themeSound;
    UIManage ui;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        ui = FindObjectOfType<UIManage>();
        if(checkTime){
            themeSound.Play();
            themeSound.loop = true;
        }
        timeTotal = timeRemaining;
    }
    
    void Update(){
        if(!checkTime){
            return;
        }
        if(isGameOver){
            scoreTime = timeTotal - timeRemaining;
            DisplayTime(scoreText,scoreTime);
            return;
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeText,timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                Cursor.lockState = CursorLockMode.None;
                ui.ShowGameOverPanel(true);
                SetGameOverState(true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        if(Input.GetKey("q"))
            {
                Cursor.lockState = CursorLockMode.None;
                ui.ShowGamePausePanel(true);
                SetGameOverState(true);
                
            }
    }
    public void Continue(){
        Cursor.lockState = CursorLockMode.Locked;
        themeSound.Play();
        themeSound.loop = true;
        ui.ShowGamePausePanel(false);
        SetGameOverState(false);
    }
    public void Replay(){
        SceneManager.LoadScene(replayScene);
    }
    public void Next(){
        SceneManager.LoadScene("StartGame");
    }
    public void SetGameOverState(bool state){
        themeSound.Stop();
        isGameOver = state;
    }
    public bool IsGameOver(){
        return isGameOver;
    }
    void DisplayTime(Text displayText,float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        displayText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
