using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManage : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameoverPanel;
    public GameObject gamewinPanel;
    public GameObject gamepausePanel;
    public AudioSource loseSound;
    public AudioSource winSound;
    void Start(){
        panel.SetActive(true);
    }
    public  void ShowGamePausePanel(bool isShow){
        if(gamepausePanel){
            gamepausePanel.SetActive(isShow);
        }
    }

    public  void ShowGameOverPanel(bool isShow){
        if(gameoverPanel){
            loseSound.Play();
            gameoverPanel.SetActive(isShow);
        }
    }
    public  void ShowGameWinPanel(bool isShow){
        if(gamewinPanel){
            winSound.Play();
            gamewinPanel.SetActive(isShow);
        }
    }
}
