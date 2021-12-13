using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class RedLightGreenLightBoss : BaseModel
    {
        public float rotateSpeed = 150f;
        public GameObject headBoss;
        private int rotateDirection = 1;
        public int minTimeSong, maxTimeSong, minTimeLook, maxTimeLook;
        private float timeWait = 0;

        void Update()
        {
            HeadRotate();

        }

        private void HeadRotate()
        {
            timeWait -= Time.deltaTime;
            if (timeWait < 0)
            {
                headBoss.transform.Rotate(Vector3.up, rotateDirection * rotateSpeed * Time.deltaTime);
            }
            float rotation = headBoss.transform.eulerAngles.y; //Get Head Rotation
            if (rotation > 180 && rotateDirection == 1)
            {
                rotateDirection = -1;
                timeWait = Random.Range(minTimeSong, maxTimeSong);
                Debug.Log("Time sing: " + timeWait);
            }
            else if (rotation < 2 && rotateDirection == -1)
            {
                rotateDirection = 1;
                timeWait = Random.Range(minTimeLook, maxTimeLook);
                Debug.Log("Time look: " + timeWait);
            }
        }
    }
}
