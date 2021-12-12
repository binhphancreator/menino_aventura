using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Model
{
    public class Player : BaseModel
    {
        public float jumpHeight = 4f;
        public float gravity = -10f;
        public float moveSpeed = 6f;
    }
}