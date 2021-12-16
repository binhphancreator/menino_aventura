using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Controller
{
    public class FirstLevelController : BaseController
    {
        private bool isPlaying;
        public static bool allowRun;
        private void Start()
        {
            isPlaying = true;
            allowRun = true;
        }
        private void Update()
        {
            Debug.Log("Allow Run: " + allowRun);
            checkMove();
        }

        public void setIsPlaying(bool newState)
        {
            isPlaying = newState;
            Debug.Log(isPlaying);
        }

        public void checkMove()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)
                || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow)
                || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (!allowRun)
                {
                    Lose();
                }
            }
        }

        public void Lose()
        {
            Debug.Log("Lose");
            isPlaying = false;
        }
    }
}