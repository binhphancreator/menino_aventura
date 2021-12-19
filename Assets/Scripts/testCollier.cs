using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class testCollier : MonoBehaviour
{
    // Start is called before the first frame update
    // TextMeshPro tm;
    GameObject textobj;
    TextMeshPro tm;
    Color cl;
    void Start()
    {
        tm = gameObject.GetComponent<TextMeshPro>();
        cl = tm.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
	{
			if (collision.gameObject.tag == "Player")
			{
				// StartCoroutine(Respawn(0.0f));
				Debug.Log("oke");
                tm.color = new Color(255, 255, 255);
			}
	}
    void OnCollisionExit(Collision collision){
        tm.color = cl;
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log(tm.text);
        }
    }
}
