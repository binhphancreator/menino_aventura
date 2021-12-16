using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    UIManager ui;

    private void Start()
    {
        ui = FindObjectOfType<UIManager>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
			ui.ShowMinigame2(true);
		}
	}
}
