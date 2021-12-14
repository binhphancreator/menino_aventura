using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Controller
{
    public class PlayerMove : BaseController
    {
        public float InputX;
	    public float InputZ;
        public float MoveSpeed = 6f;
        public CharacterController Controller;
        public Transform cam;
        public float gravity = -10f;
        Vector3 fall;
        public float jumpHigh = 4f;
        //public Transform groundCheck;
        public LayerMask layer;
        bool isGround;
        public Animator anim;
        public float Speed;
        public float allowPlayerRotation = 0.1f;
        [Header("Animation Smoothing")]
        [Range(0, 1f)]
        public float HorizontalAnimSmoothTime = 0.2f;
        [Range(0, 1f)]
        public float VerticalAnimTime = 0.2f;
        [Range(0,1f)]
        public float StartAnimTime = 0.5f;
        [Range(0, 1f)]
        public float StopAnimTime = 0.1f;

        void Start(){
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            isGround = Controller.isGrounded;
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            // Player face to camera direction
            Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
            float angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            // player face to move direction
            if(move != Vector3.zero){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.3f);
                Controller.Move(moveDir * MoveSpeed * Time.deltaTime);
            }

            if(isGround && fall.y < 0){
                fall.y = -2f; 
            }

            // jump
            if(Input.GetButtonDown("Jump") && isGround == true){
                fall.y = Mathf.Sqrt(jumpHigh * gravity * -2f);
            }

            fall.y += gravity * Time.deltaTime;

            Controller.Move(fall * Time.deltaTime);
            //Calculate Input Vectors
            InputX = Input.GetAxis ("Horizontal");
            InputZ = Input.GetAxis ("Vertical");

            //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
            //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

            //Calculate the Input Magnitude
            Speed = new Vector2(InputX, InputZ).sqrMagnitude;

            //Physically move player

            if (Speed > allowPlayerRotation) {
                anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
                
            } else if (Speed < allowPlayerRotation) {
                anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
            }
            
        }
        
        
	}
}