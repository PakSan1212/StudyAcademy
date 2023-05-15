using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
  
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Animating(h, v);
        Turning();
    }
    Vector3 movement;
    float speed = 6f;
    private void Move(float h,float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * Time.fixedDeltaTime * speed;
        transform.position += movement;
    }
    private void Animating(float h, float v)
    {
        bool waking = h != 0f || v != 0f;
        animator.SetBool("IsWalking", waking);
    }

    float camRayLength = 100f;
    int floorMask;
    void Turning()
    {
        floorMask = LayerMask.GetMask("Floor");
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        //충돌 했을때
        if(Physics.Raycast(camRay,out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point;
            playerToMouse.y = transform.position.y;

            transform.LookAt(playerToMouse);

            //Quaternion rotation = Quaternion.LookRotation(playerToMouse);
            ////transform.rotation = rotation;
            ///
            //Rigidbody rigid = GetComponent<Rigidbody>();
            //rigid.MoveRotation(rotation);

            //transform.position = playerToMouse;
            //transform.position = Vector3.Lerp(transform.position,
            //    playerToMouse, Time.fixedDeltaTime * 6);
        }
    }

}
