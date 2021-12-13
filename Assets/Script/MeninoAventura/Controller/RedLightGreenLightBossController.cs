using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class RedLightGreenLightBossController : MonoBehaviour
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
            bossModel.HeadRotate();
        }
    }
}