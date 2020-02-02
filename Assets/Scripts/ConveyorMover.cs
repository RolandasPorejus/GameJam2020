using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMover : MonoBehaviour
{
    public float speed;
    public float visualSpeed;

    private Vector3 direction;
    private Vector2[] textureOffsets;
    public int currTextureScroll;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        textureOffsets = new Vector2[] { new Vector2(0,0), new Vector2(0, 0.46875f), new Vector2(0.46875f, 0), new Vector2(0.46875f, 0.46875f) };
    }

    // Update is called once per frame
    void Update()
    {
        //Texture scrolling offsets
        //0,0 0,60 60,0 60,60
        timer += Time.deltaTime * visualSpeed;

        if (timer >= 4.0f)
        {
            timer = 4.0f;
            currTextureScroll = 3;
        }
        else if (timer == 0)
        {
            currTextureScroll = 0;
        }
        else
        {
            currTextureScroll = (int)Math.Ceiling(Convert.ToDouble(timer) - 1.0);
        }
        GetComponent<Renderer>().material.mainTextureOffset = textureOffsets[currTextureScroll];

        if (timer >= 4.0f)
        {
            timer = 0.0f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        direction = -transform.up;
        direction = direction * speed;
        collision.rigidbody.AddForce(direction, ForceMode.Acceleration);
    }
}