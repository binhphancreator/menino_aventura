using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class FirstLevelController : BaseController
    {
        public static bool isPlaying = false, isStart = false;
        public GameObject barrier;
        public static bool allowRun;
        public MenuController menuController;
        public GameObject enegyBox;
        public static int score;

        private void Start()
        {
            isPlaying = false;
            isStart = false;
            allowRun = true;
            score = 0;
            Spawn();
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
            if (Input.GetKey("escape"))
            {
                SceneManager.LoadScene("StartGame");
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
            isStart = false;
            if (score < 8)
            {
                Lose();
            }
            else
            {
                isPlaying = false;
                Debug.Log("Win");
                Cursor.lockState = CursorLockMode.None;
                menuController.messageText.text = "You win!";
                menuController.ShowMenu();
            }
        }

        public void Lose()
        {
            isStart = false;
            isPlaying = false;
            Debug.Log("Lose");
            Cursor.lockState = CursorLockMode.None;
            menuController.messageText.text = "You lose!";
            menuController.ShowMenu();

        }

        public void RemoveBarrier()
        {
            if (TimeController.seconds > 6)
            {
                Destroy(barrier);
            }
        }

        public void Spawn()
        {
            Vector3 spawnPos = new Vector3(Random.Range(-9, 7), 0, Random.Range(-26, 22));
            if (enegyBox)
            {
                Instantiate(enegyBox, spawnPos, Quaternion.identity);
            }
        }
    }
}