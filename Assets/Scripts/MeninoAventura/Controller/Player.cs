using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Model
{
    public class Player : BaseModel
    {
        public float MoveSpeed = 5f;
        public float gravity = -50f;
        public Vector3 fall;
        public float jumpHigh = 1f;
        public bool isGround;
        public float allowPlayerRotation = 0.1f;
        public Vector3 checkPoint;

        [Header("Animation Smoothing")]
        [Range(0, 1f)]
        public float HorizontalAnimSmoothTime = 0.2f;
        [Range(0, 1f)]
        public float VerticalAnimTime = 0.2f;
        [Range(0,1f)]
        public float StartAnimTime = 0.5f;
        [Range(0, 1f)]
        public float StopAnimTime = 0.1f;
    }
}