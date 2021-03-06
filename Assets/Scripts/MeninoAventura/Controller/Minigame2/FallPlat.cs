using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FallPlat : MonoBehaviour
{
	public float timeRespawn = 5.0f;

	void OnCollisionEnter(Collision collision)
	{
			if (collision.gameObject.tag == "Player")
			{
				// StartCoroutine(Respawn(0.0f));
				gameObject.SetActive(false);
				Invoke("Respawn",timeRespawn);
			}
	}

	// IEnumerator Respawn( float timeToRespawn) {
	// 	// yield return new WaitForSeconds(timeToDespawn);
	// 	gameObject.SetActive(false);
	// 	Debug.Log("False");
	// 	yield return new WaitForSeconds(timeToRespawn);
	// 	gameObject.SetActive(true);
	// 	Debug.Log("True");
	// }
	void Respawn(){
		GameObject box = (GameObject)Instantiate(gameObject);
		box.transform.position = transform.position;
		box.SetActive(true);
		Destroy(gameObject);

	}
}
