using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Controller 
{
    public class PlayerMovement : BaseController
    {
        public CharacterController Controller;
        private Transform cameraTransform;
        public Transform playerTransform;
        public Animator playerAnimator;
        public Model.Player model;
        public Rigidbody rigidbodyPlayer;

        void Start() {
            init();
        }

        private void init()
        {
            Cursor.lockState = CursorLockMode.Locked;
            rigidbodyPlayer.freezeRotation = true;
            rigidbodyPlayer.useGravity = false;
            model.checkPoint = playerTransform.position;
            cameraTransform = Camera.main.transform;
        }

        public void LoadCheckPoint()
        {
            playerTransform.position = model.checkPoint;
            Physics.SyncTransforms();
        }

        void FixedUpdate() {
            
        }

        void Update()
        {
            checkGround();
            jump();
            movePlayerBycameraTransformeraDirection();
        }

        private void checkGround()
        {
            if(Controller.isGrounded && model.fall.y < 0){
                model.fall.y = -10f; 
            }
            model.fall.y += model.gravity * Time.deltaTime;  
            Controller.Move(model.fall * Time.deltaTime);

            if(!Controller.isGrounded){
                playerAnimator.SetBool("isJumping",false);
            }
        }

        private void movePlayerBycameraTransformeraDirection()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            
            // Player face to cameraTransformera direction
            Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
            float angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            if(move != Vector3.zero){
                playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.LookRotation(moveDir), 0.3f);
                Controller.Move(moveDir * model.MoveSpeed * Time.deltaTime);
            }

            //Calculate the Input Magnitude
            float Speed = new Vector2(horizontal, vertical).sqrMagnitude;

            //Physically move player

            if (Speed > model.allowPlayerRotation) {
                playerAnimator.SetFloat("Blend", Speed, model.StartAnimTime, Time.deltaTime);
            } else if (Speed < model.allowPlayerRotation) {
                playerAnimator.SetFloat("Blend", Speed, model.StopAnimTime, Time.deltaTime);
            }
        }

        private void jump()
        {
            // jump
            if(Controller.isGrounded && Input.GetButtonDown("Jump")){
                model.fall.y = Mathf.Sqrt(model.jumpHigh * model.gravity * -2f);
                playerAnimator.SetBool("isJumping",true);
            }
        }
	}
}