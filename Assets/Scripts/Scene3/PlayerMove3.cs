using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
        public float InputX;
	    public float InputZ;
        public Vector3 checkPoint;
        public float MoveSpeed = 5f;
        public float gravity = -50f;
        public float jumpHigh = 1f;
        public Vector3 fall;
        public bool isGround;
        public float Speed;
        float allowPlayerRotation = 0.1f;
        private Rigidbody rb;
        public AudioSource runSound,dieSound;
        public CharacterController Controller;
        public Animator anim;
        // public GameObject player;
        Game3Controller gameController;

        [Header("Animation Smoothing")]
        [Range(0, 1f)]
        public float HorizontalAnimSmoothTime = 0.2f;
        [Range(0, 1f)]
        public float VerticalAnimTime = 0.2f;
        [Range(0,1f)]
        public float StartAnimTime = 0f;
        [Range(0, 1f)]
        public float StopAnimTime = 0f;

        void Start(){
            Cursor.lockState = CursorLockMode.Locked;
            rb = GetComponent<Rigidbody>();
            gameController = FindObjectOfType<Game3Controller>();

            rb.freezeRotation = true;
            rb.useGravity = false;
            checkPoint = transform.position;
        }

        // void Awake () {
            
        // }

        public void LoadCheckPoint()
        {
            dieSound.Play();
            transform.position = checkPoint ;
            Physics.SyncTransforms();
            // player.SetActive(false);
            // StartCoroutine(Wait(0.25f));
            
        }
        // IEnumerator Wait(float time)
        // {
        //     Debug.Log("respawn");
        //     yield return new WaitForSeconds(time);
        //     player.SetActive(true);
        //     transform.position = checkPoint ;
        //     Physics.SyncTransforms();
        // }

        void Update()
        {
            isGround = Controller.isGrounded;
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            // float vertical = Input.GetAxisRaw("Vertical");
            
            // Player face to camera direction
            // Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
            Vector3 move = new Vector3(0f, 0f, horizontal).normalized;
            float angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg ;
            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            
            if(gameController.IsGameOver()) {
                Controller.Move(moveDir*0);
                return;
            }
            // player face to move direction
            
            if(move != Vector3.zero){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.3f);
                
                Controller.Move(moveDir * MoveSpeed * Time.deltaTime);
            }

            if(isGround && fall.y < 0){
                fall.y = -15f; 
                
            }

            // jump
            if(Input.GetKeyDown("up")&& isGround == true||Input.GetKeyDown("w") && isGround == true){
                
                fall.y = Mathf.Sqrt(jumpHigh * gravity * -2f);
                anim.SetBool("isJumping",true);
                Jumpsound();
            }
            
            if(!isGround){
                anim.SetBool("isJumping",false);
            }

            fall.y += gravity * Time.deltaTime;
            
            Controller.Move(fall * Time.deltaTime);
            //Calculate Input Vectors
            InputX = Input.GetAxis ("Horizontal");
            // InputZ = Input.GetAxis ("Vertical");

            //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
            //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

            //Calculate the Input Magnitude
            Speed = new Vector2(InputX, 0).sqrMagnitude;

            //Physically move player

            if (Speed > allowPlayerRotation) {
                anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
                
                
            } else if (Speed < allowPlayerRotation) {
                anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
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
        
