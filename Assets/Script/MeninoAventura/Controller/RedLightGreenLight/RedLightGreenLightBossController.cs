using Core;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class RedLightGreenLightBossController : BaseController
    {
        public GameObject headBoss;
        public AudioClip audioClip;
        AudioSource song;
        private RedLightGreenLightBossModel bossModel;

        private void Start()
        {
            song = gameObject.AddComponent<AudioSource>();
            song.clip = audioClip;
            bossModel = new RedLightGreenLightBossModel(headBoss, song);
        }

        void Update()
        {
            if (FirstLevelController.isPlaying)
            {
                bossModel.HeadRotate();
                if (bossModel.getIsSing())
                {
                    FirstLevelController.allowRun = true;
                }
                else
                {
                    FirstLevelController.allowRun = false;
                }
            }
            else
            {
                bossModel.song.Pause();
            }
        }
    }
}