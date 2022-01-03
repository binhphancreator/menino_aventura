using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Model.Player player;
    public Transform checkPoint;
    Vector3 a = new Vector3(0,2,0);
    private AudioSource breaksound;
   void Start(){
	   breaksound = GameObject.Find("/Controller/Sound/checkpoint1").GetComponent<AudioSource>();
   }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
            breaksound.Play();
			player.checkPoint = checkPoint.position + a;
            Destroy(gameObject);
		}
	}
}
