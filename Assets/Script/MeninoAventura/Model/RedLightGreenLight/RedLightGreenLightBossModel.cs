using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class RedLightGreenLightBossModel : BaseModel
    {
        public GameObject headBoss;
        public AudioSource song;
        public float rotateSpeed;
        private int rotateDirection;
        public int minTimeSong, maxTimeSong, minTimeLook, maxTimeLook;
        private float timeWait;
        private bool isSing;

        public RedLightGreenLightBossModel(GameObject gameObject, AudioSource audioSource)
        {
            this.headBoss = gameObject;
            this.song = audioSource;
            this.rotateSpeed = 150f;
            this.rotateDirection = 1;
            this.minTimeSong = 2;
            this.maxTimeSong = 8;
            this.minTimeLook = 2;
            this.maxTimeLook = 4;
            this.timeWait = 5;
            this.isSing = true;
            this.song.Play();
        }

        public void HeadRotate()
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
                timeWait = Random.Range(minTimeLook, maxTimeLook);
                IsSing(false);
                this.song.Pause();
            }
            else if (rotation < 2 && rotateDirection == -1)
            {
                rotateDirection = 1;
                timeWait = Random.Range(minTimeSong, maxTimeSong);
                IsSing(true);
                this.song.Play();
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