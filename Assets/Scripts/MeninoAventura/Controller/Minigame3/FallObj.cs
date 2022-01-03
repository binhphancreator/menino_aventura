using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObj : MonoBehaviour
{
    // public float moveSpeed = 2f;
    // Rigidbody m_rb;


    // // Start is called before the first frame update
    // void Start()
    // {
    //     m_rb = GetComponent<Rigidbody> ();

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //      m_rb.velocity = Vector3.down * moveSpeed;

    // }
    // private void OnCollisionEnter(Collision col){
    //     if (col.gameObject.tag == "KillZone")
    //         {
    //              Destroy(gameObject);
                
    //         }
    // }

	public float speed = 3f;
	public float offset = 0f; //If yo want to modify the position at the start 
	private Vector3 startPos;
    Rigidbody m_rb;
    GameManage gc;
   

   void Start()
    {
        gc = FindObjectOfType<GameManage>();
        m_rb = GetComponent<Rigidbody> ();
        startPos = transform.position;
        transform.position += Vector3.up * offset;

    }

    // Update is called once per frame
    void Update()
    {
        if(gc.IsGameOver()) {
                return;
            }
        transform.position -= Vector3.up * Time.deltaTime * speed ;
				
		
    }
    private void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "KillZone")
            {
                 Destroy(gameObject);
                
            }
    }
}
