using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3Manager : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameoverPanel;
    public GameObject gamewinPanel;

    void Start(){
        panel.SetActive(true);
    }

    public  void ShowGameOverPanel(bool isShow){
        if(gameoverPanel){
            gameoverPanel.SetActive(isShow);
        }
    }
    public  void ShowGameWinPanel(bool isShow){
        if(gamewinPanel){
            gamewinPanel.SetActive(isShow);
        }
    }
}
