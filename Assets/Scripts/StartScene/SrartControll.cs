using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SrartControll : MonoBehaviour
{
    UIManager ui;

    private void Start()
    {
        ui = FindObjectOfType<UIManager>();
    }
    public void Back(){
        ui.ShowMinigame2(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void LoadMinigame2(){
        SceneManager.LoadScene("Scene2");
    }
}
