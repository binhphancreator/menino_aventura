using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone3 : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
			col.gameObject.GetComponent<PlayerMove3>().LoadCheckPoint();
		}
	}
    
}
