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
    bool getWord = false;
    void Start()
    {
        tm = gameObject.GetComponent<TextMeshPro>();
        cl = tm.color;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && getWord == true){
            tmp.GetComponent<TextControll>().checkWord(tm.text);
        }
    }

    void OnCollisionEnter(Collision collision)
	{
			if (collision.gameObject.tag == "Player")
			{
                getWord = true;
                tm.color = new Color(255, 255, 255, 255);
			}
	}
    void OnCollisionExit(Collision collision){
        getWord = false;
        tm.color = cl;
    }
}
