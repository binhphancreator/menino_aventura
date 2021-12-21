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
    public Text timeText;
    // public TextMeshPro timeTextMesh;
    UIManage ui;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        ui = FindObjectOfType<UIManage>();
    }
    
    void Update(){
        if(isGameOver||!checkTime){
            return;
        }
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
                ui.ShowGameOverPanel(true);
                SetGameOverState(true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    public void Replay(){
        SceneManager.LoadScene(replayScene);
    }
    public void Next(){
        SceneManager.LoadScene("StartGame");
    }
    public void SetGameOverState(bool state){
        isGameOver = state;
    }
    public bool IsGameOver(){
        return isGameOver;
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        // timeTextMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
