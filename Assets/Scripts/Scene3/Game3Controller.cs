using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game3Controller : MonoBehaviour
{
    public bool isGameOver;
    void Update(){
        if(isGameOver){
            return;
        }
    }
    public void Replay(){
        SceneManager.LoadScene("Scene3");
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
}
