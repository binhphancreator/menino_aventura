using Controller;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class WinTrigger : BaseController
    {
        public FirstLevelController firstLevelController;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if(FirstLevelController.isPlaying)
                {
                    firstLevelController.Win();
                    Destroy(gameObject);
                }
            }
        }
    }
}