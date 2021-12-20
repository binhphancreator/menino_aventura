using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class RedLightGreenLightBossModel : BaseModel
    {
        public GameObject headBoss;
        public AudioSource GreenLight, RedLight;
        public float rotateSpeed;
        public int rotateDirection;
        public int minTimeSong, maxTimeSong, minTimeLook, maxTimeLook;
        public float timeWait;
        private bool isSing;

        public void HeadRotate()
        {
            timeWait -= Time.deltaTime;
            if (timeWait < 0)
            {
                headBoss.transform.Rotate(Vector3.up, rotateDirection * rotateSpeed * 0.01f);
            }
            float rotation = headBoss.transform.eulerAngles.y; //Get Head Rotation
            if (rotation > 180 && rotateDirection == 1)
            {
                rotateDirection = -1;
                timeWait = Random.Range(minTimeLook, maxTimeLook);
                IsSing(false);
                RedLight.Play();
                
            }
            else if (rotation < 2 && rotateDirection == -1)
            {
                rotateDirection = 1;
                timeWait = Random.Range(minTimeSong, maxTimeSong);
                IsSing(true);
                GreenLight.Play();
            }
        }

        public void IsSing(bool IsSing)
        {
            this.isSing = IsSing;
        }
        public bool getIsSing()
        {
            return this.isSing;
        }
    }
}