using Core;
using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class RedLightGreenLightBossController : BaseController
    {
        public RedLightGreenLightBossModel bossModel;

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
                    if(TimeLevel1Controller.timer > 8)
                    {
                        FirstLevelController.allowRun = false;
                    }
                }
            }
        }
    }
}