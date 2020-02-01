using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    //private GameObject camera;

    public float moveSpeed;
    public float jumpForce;
    Vector3 jump;
    bool jumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //camera = GameObject.Find("Main Camera");
        //rb.inertiaTensor = rb.inertiaTensor + new Vector3(0, 0, rb.inertiaTensor.z * 100);
    }

    void Update()
    {
        if (!GetComponent<GameEnd>().Dead)
        {
            float horMove = moveSpeed * Input.GetAxis("Horizontal");
            float vertMove = moveSpeed * Input.GetAxis("Vertical");

            if (horMove != 0 || vertMove != 0)
            {
                var move_vec = new Vector3(horMove, 0, vertMove);
                //Debug.Log(move_vec);

                move_vec = Camera.main.transform.TransformDirection(move_vec);

                Vector3 v = rb.velocity;
                v.x = move_vec.x;
                v.z = move_vec.z;
                rb.velocity = v;
            }

            if (CanJump() && Math.Abs(rb.velocity.y) < 0.01)
            {
                jumping = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CanJump())
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumping = true;
                }
            }


            if (horMove == 0 && vertMove == 0 && !jumping)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    bool CanJump()
    {
        Ray ray = new Ray(transform.position, transform.up * -1);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, transform.localScale.y + 0.2f))
        {
            return true;
        }
        return false;
    }

        void MovePlayer(float horizontal, float vertical)
    {
        //transform.localEulerAngles = Camera.main.transform.localEulerAngles;
        /*
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);

        Vector3 vel;
        Vector3 forwardVel = transform.forward * vertical;
        Vector3 horizontalVel = transform.right * horizontal;
        vel = forwardVel + horizontalVel;
        vel.y = rb.velocity.y;
        rb.velocity = vel;

        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, rb.velocity, speed * Time.deltaTime, 0.0f);
        //transform.rotation = Quaternion.LookRotation(newDirection);

        //camera.GetComponent<CameraController>().UpdatePosition();
        */
    }
}
