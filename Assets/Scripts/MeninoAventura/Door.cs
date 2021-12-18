using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject menu;
    public string minigame;

    private void Start()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
			menu.SetActive(true);
		}
	}

    void OnCollisionExit(Collision other) {
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(minigame);
    }
}
