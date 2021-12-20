using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class TimeLevel1Controller : TimeController
    {
        public GameObject CountDown;
        private void Update()
        {
            string min = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
            string sec = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
            if (FirstLevelController.isPlaying)
            {
                Timer();
                time.text = "Time: " + min + ":" + sec;
            }
            else if (!FirstLevelController.isStart)
            {
                if(!CountDown())
                {
                    Destroy(CountDown);
                    FirstLevelController.isPlaying = true;
                    FirstLevelController.isStart = true;
                }
            }
        }
    }
}
