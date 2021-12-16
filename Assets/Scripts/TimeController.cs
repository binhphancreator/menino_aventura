using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class TimeController : MonoBehaviour
    {
        public Text time;
        [SerializeField]
        private TextMeshPro countDownTmp;
        //private float seconds, minutes;

        public static float timer = 0.0f;
        public static int minutes, seconds;
        public static bool keepTiming = true;

        void Start()
        {
            seconds = 0;
        }

        public static void Timer()
        {
            // seconds
            timer += Time.deltaTime;
            // turn float to int
            minutes = (int)(timer / 60);
            seconds = (int)(timer % 60);
        }

        public static void ResetTimer()
        {
            // seconds
            timer += Time.deltaTime;
            // turn float seconds to int
            seconds = (int)(timer % 60);

            if (seconds > 4 || true)
            {
                // both code runs the same
                timer = 0.0f;
            }
        }

        public static void StopTimer()
        {
            if (keepTiming)
            {
                // seconds
                timer += Time.deltaTime;
                // turn float seonds to int
                seconds = (int)(timer % 60);
            }

            if (seconds > 4)
            {
                // stop and record time
                keepTiming = false;
            }
        }

        public bool CountDown()
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
            int countDownTime = 5 - seconds;
            if (countDownTime >= 0)
            {
                countDownTmp.text = countDownTime + "";
            }
            else
            {
                countDownTmp.text = "Start";
            }
            if (seconds > 6)
            {
                Destroy(countDownTmp);
                ResetTimer();
                return false;
            }
            return true;
        }
    }
}
