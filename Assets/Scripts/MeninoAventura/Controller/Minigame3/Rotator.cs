using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 3f;
    public bool direct =true;
    int a=1;
    GameManage gc;
    void Start(){
        gc = FindObjectOfType<GameManage>();
    }
    void Update()
    {
        if(gc.IsGameOver()) {
                return;
            }
      if(direct){
          a=1;
      }
      else a=-1;
		transform.Rotate(Vector3.up, a * 150 * Time.deltaTime);
	}
}
