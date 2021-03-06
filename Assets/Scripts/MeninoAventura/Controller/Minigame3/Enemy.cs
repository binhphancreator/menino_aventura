using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float distance = 5f; //Distance that moves the object
	public bool horizontal = true; //If the movement is horizontal or vertical
	public float speed = 3f;
	public float offset = 0f; //If yo want to modify the position at the start 
    public bool rot = true;
	private bool isForward = true; //If the movement is out
	private Vector3 startPos;
	public Controller.PlayerMovement player;
	GameManage gc;
	AudioSource effectSound;
    
    void Start()
    {
		gc = FindObjectOfType<GameManage>();
		effectSound = gameObject.GetComponent<AudioSource>();
		startPos = transform.position;
		if (horizontal)
			transform.position += Vector3.up * offset;
		else
			transform.position += Vector3.forward * offset;
	}

    // Update is called once per frame
    void Update()
    {
		if(gc.IsGameOver()) {
				effectSound.Stop();
                return;
            }

		if (horizontal)
		{
			if (isForward)
			{
				if (transform.position.y < startPos.y + distance)
				{
					transform.position += Vector3.up * Time.deltaTime * speed ;
				}
				else
					isForward = false;
			}
			else
			{
				if (transform.position.y >= startPos.y)
				{
					transform.position -= Vector3.up * Time.deltaTime * speed ;
				}
				else
					isForward = true;
			}
		}
		else
		{
			if (isForward)
			{
				if (transform.position.z < startPos.z + distance)
				{
					transform.position += Vector3.forward * Time.deltaTime * speed ;
				}
				else{
                    Rotator();
                    isForward = false;
                }
					
			}
			else
			{
				if (transform.position.z >= startPos.z)
				{
					transform.position -= Vector3.forward * Time.deltaTime * speed ;
				}
				else{
                    Rotator();
                    isForward = true;
                }
					
			}
		}
    }
    void Rotator(){
        if(rot){
            transform.Rotate(Vector3.up, 180);
        }
        else return;
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
			player.LoadCheckPoint();
		}
	}
}
