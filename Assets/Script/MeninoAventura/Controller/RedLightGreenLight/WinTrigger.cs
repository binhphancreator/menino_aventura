using Controller;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class WinTrigger : BaseController
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if(FirstLevelController.isPlaying)
                {
                    FirstLevelController.isPlaying = false;
                    Destroy(gameObject);
                    Debug.Log("Win");
                }
            }
        }
    }
}