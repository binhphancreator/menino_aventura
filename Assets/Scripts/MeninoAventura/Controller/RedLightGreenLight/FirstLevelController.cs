using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Controller
{
    public class FirstLevelController : BaseController
    {
        public static bool isPlaying, isStart;
        public GameObject barrier;
        public static bool allowRun;
        private void Start()
        {
            isStart = false;
            isPlaying = false;
            allowRun = false;
        }
        private void Update()
        {
            Debug.Log("Is playing: " + isPlaying);
            if(isStart)
            {
                RemoveBarrier();
            }
            if (isPlaying)
            {
                checkMove();
            }
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

        public static void Lose()
        {
            Debug.Log("Lose");
            isPlaying = false;
        }

        public void RemoveBarrier()
        {
            if (TimeController.seconds > 6)
            {
                Destroy(barrier);
            }
        }
    }
}