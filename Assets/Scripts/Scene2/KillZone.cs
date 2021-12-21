using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public Controller.PlayerMovement player;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
			player.LoadCheckPoint();
		}
	}
}
