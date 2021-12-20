using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    private Text scoreTxt;
    private FirstLevelController firstLevelController;

    private void Start()
    {
        scoreTxt = GameObject.Find("Score").GetComponent<Text>();
        firstLevelController = GameObject.Find("Controller").GetComponent<FirstLevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FirstLevelController.score++;
            scoreTxt.text = "Score: " + FirstLevelController.score;
            Destroy(gameObject);
            firstLevelController.Spawn();
        }
    }
}
