using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject camera;

    public float speed;
    public float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera");

        moveSpeed = 4.0F;
        speed = moveSpeed;
    }

    void Update()
    {
        speed = moveSpeed;

        float horMove = speed * Input.GetAxis("Horizontal");
        float vertMove = speed * Input.GetAxis("Vertical");

        if (horMove != 0 || vertMove != 0)
        {
            var move_vec = new Vector3(horMove, 0, vertMove);
            Debug.Log(move_vec);

            move_vec = Camera.main.transform.TransformDirection(move_vec);
            move_vec.y = 0.0f;
            rb.velocity = move_vec;
        }

        if (horMove == 0 && vertMove == 0) {
            rb.velocity = Vector3.zero;
        }
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
