﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
   public float time = 0.1f;

	void OnCollisionEnter(Collision collision)
	{
			if (collision.gameObject.tag == "Player")
			{
				// StartCoroutine(Respawn(0.0f));
				
				Invoke("Display",time);
                Invoke("Respawn",5);
			}
	}
    void Display(){
        gameObject.SetActive(false);
    }
	void Respawn(){
		GameObject box = (GameObject)Instantiate(gameObject);
		box.transform.position = transform.position;
		box.SetActive(true);
		Destroy(gameObject);

	}

}
