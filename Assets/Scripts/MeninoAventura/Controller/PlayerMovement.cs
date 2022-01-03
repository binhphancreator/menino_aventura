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
        GameManage gc;
        Vector3 moveDir;
        public bool isGround = true;
        public AudioSource runSound,dieSound;

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
            gc = FindObjectOfType<GameManage>();
        }

        public void LoadCheckPoint()
        {
            dieSound.Play();
            playerTransform.position = model.checkPoint;
            Physics.SyncTransforms();
        }
        void Update()
        {
            isGround = Controller.isGrounded;
            if(gc.IsGameOver()) {
                playerAnimator.SetFloat("Blend", 0, model.StopAnimTime, Time.deltaTime);
                Controller.Move(moveDir*0);
                return;
            }
            checkGround();
            
            model.fall.y += model.gravity * Time.deltaTime;  
            Controller.Move(model.fall * Time.deltaTime);
            if(Controller.isGrounded){
                if(model.fall.y < 0){
                model.fall.y = -5f; 
            }
                jump();
            }
            if(!Controller.isGrounded){
                playerAnimator.SetBool("isJumping",false);
            }
            movePlayerBycameraTransformeraDirection();
        }

        private void checkGround()
        {
            if(!Controller.isGrounded){
                playerAnimator.SetBool("isJumping",false);
            }
        }

        private void movePlayerBycameraTransformeraDirection()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = 0;
            Vector3 move ;
            float angle ;
            
            if(!model.lockVertical){
                vertical = Input.GetAxisRaw("Vertical");
                move = new Vector3(horizontal, 0f, vertical).normalized;
                angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            }
            else{
                move = new Vector3(0f, 0f, horizontal).normalized;
                angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            } 
            
            // Player face to cameraTransformera direction
            
            // float angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

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
            if(model.lockVertical){
                if(Input.GetKeyDown("up")||Input.GetKeyDown("w")){
                model.fall.y = Mathf.Sqrt(model.jumpHigh * model.gravity * -2f);
                playerAnimator.SetBool("isJumping",true);
                Jumpsound();
                }
            }
            if( Input.GetButtonDown("Jump")){
                model.fall.y = Mathf.Sqrt(model.jumpHigh * model.gravity * -2f);
                playerAnimator.SetBool("isJumping",true);
                Jumpsound();
            }
        }
        private void Jumpsound(){
            runSound.Play();
        }
        private void Runsound(){
            if(Controller.isGrounded){
                
                runSound.Play();
            }
            else return;
            
        }
	}
}