using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public Button replayBtn, exitBtn;
    public Text messageText;

    void Start()
    {
        replayBtn.onClick.AddListener(replay);
        exitBtn.onClick.AddListener(exit);
    }

    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exit()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }
    public void ShowMenu()
    {
        menu.SetActive(true);
    }
}
