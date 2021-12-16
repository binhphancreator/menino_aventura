using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    FirstLevelController firstLevelController;

    private void Start()
    {
        firstLevelController = new FirstLevelController();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Win");
            firstLevelController.setIsPlaying(false);
            Destroy(gameObject);
        }
    }
}