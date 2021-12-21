using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    UIManage ui;
    GameManage gc;

    private void Start()
    {
        ui = FindObjectOfType<UIManage>();
        gc = FindObjectOfType<GameManage>();
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
