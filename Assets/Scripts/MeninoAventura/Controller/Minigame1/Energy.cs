using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    private Text scoreTxt;
    private FirstLevelController firstLevelController;
    public AudioSource audio;
    public GameObject winTrigger;
    public Color color;
    private void Start()
    {
        audio = GameObject.Find("EnergySfx").GetComponent<AudioSource>();
        scoreTxt = GameObject.Find("Score").GetComponent<Text>();
        firstLevelController = GameObject.Find("Controller").GetComponent<FirstLevelController>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audio.Play();
            FirstLevelController.score++;
            scoreTxt.text = "Score: " + FirstLevelController.score;
            Destroy(gameObject);
            firstLevelController.Spawn();
            if (FirstLevelController.score >= firstLevelController.winScore)
            {
                winTrigger.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.2f);
            }
        }
        
    }
}
