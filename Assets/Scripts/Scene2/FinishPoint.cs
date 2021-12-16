using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    UI2Manager ui2;
    Game2Controller gc;

    private void Start()
    {
        ui2 = FindObjectOfType<UI2Manager>();
        gc = FindObjectOfType<Game2Controller>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            Cursor.lockState = CursorLockMode.None;
			ui2.ShowGameWinPanel(true);
            gc.SetGameOverState(true);
		}
	}
}
