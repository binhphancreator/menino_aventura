using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint3 : MonoBehaviour
{
    UI3Manager ui;
    Game3Controller gc;

    private void Start()
    {
        ui = FindObjectOfType<UI3Manager>();
        gc = FindObjectOfType<Game3Controller>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            Cursor.lockState = CursorLockMode.None;
			ui.ShowGameWinPanel(true);
            gc.SetGameOverState(true);
		}
	}
}
