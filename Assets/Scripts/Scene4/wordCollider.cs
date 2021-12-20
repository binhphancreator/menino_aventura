using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class wordCollider : MonoBehaviour
{
    // Start is called before the first frame update
    // TextMeshPro tm;
    public TextMeshPro tmp;
    TextMeshPro tm;
    Color cl;
    void Start()
    {
        tm = gameObject.GetComponent<TextMeshPro>();
        cl = tm.color;
    }

    void OnCollisionEnter(Collision collision)
	{
			if (collision.gameObject.tag == "Player")
			{
                tm.color = new Color(255, 255, 255, 255);
			}
	}
    void OnCollisionExit(Collision collision){
        tm.color = cl;
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if(Input.GetKeyDown(KeyCode.F)){
            tmp.GetComponent<TextControll>().checkWord(tm.text);
        }
    }
}
