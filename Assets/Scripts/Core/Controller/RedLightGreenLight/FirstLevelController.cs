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
        public MenuController menuController;
        private void Start()
        {
            isStart = false;
            isPlaying = false;
            allowRun = true;
        }
        private void Update()
        {
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

        public void Win()
        {
            Debug.Log("Win");
            Cursor.lockState = CursorLockMode.None;
            menuController.messageText.text = "You win!";
            isPlaying = false;
            isStart = false;
            menuController.ShowMenu();
        }

        public void Lose()
        {
            Debug.Log("Lose");
            Cursor.lockState = CursorLockMode.None;
            menuController.messageText.text = "You lose!";
            isPlaying = false;
            isStart = false;
            menuController.ShowMenu();

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