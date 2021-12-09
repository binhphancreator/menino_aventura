using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float MoveSpeed = 6f;
    public CharacterController Controller;
    public Transform cam;
    public float gravity = -10f;
    Vector3 fall;
    public float jumpHigh = 4f;
    public Transform groundCheck;
    public LayerMask layer;
    bool isGround;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // sphere check ground
        isGround = Physics.CheckSphere(groundCheck.position, 0.2f, layer);

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
    }
}
