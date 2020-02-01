using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherSystem : MonoBehaviour
{
    public bool harmful;
    public bool xMove;
    public bool yMove;
    public bool zMove;
    public float speed;

    public float maxMove = 5; 
    public float minMove = 0; 
    float currentPosition = 0;
    float direction = 1;

    public int diffTreshold;
    float timer = 0.0f;
    public float waitingTime;
    bool timerBegin;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (diffTreshold >= DifficultySystem.Difficulty)
        {
            if (!timerBegin)
            {
                currentPosition += Time.deltaTime * direction * speed; // or however you are incrementing the position

                if (currentPosition >= maxMove)
                {
                    direction *= -1;
                    currentPosition = maxMove;
                }
                else if (currentPosition <= minMove)
                {
                    direction *= -1;
                    currentPosition = minMove;
                }
            }

            if (currentPosition == minMove)
            {
                timerBegin = true;
            }
            if (timerBegin) {
                timer += Time.deltaTime;
            }
            if(timer >= waitingTime)
            {
                timer = 0.0f;
                timerBegin = false;
            }

            if (!timerBegin)
            {
                if (xMove)
                {
                    transform.position = transform.position + (Vector3.right * Time.deltaTime * direction * speed);
                }
                if (yMove)
                {
                    transform.position = transform.position + (Vector3.up * Time.deltaTime * direction * speed);
                }
                if (zMove)
                {
                    transform.position = transform.position + (Vector3.forward * Time.deltaTime * direction * speed);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (harmful)
        {
            if (collision.gameObject.tag == "Box")
            {
                if (Player.GetComponent<PlayerPickup>().carrying && (Player.GetComponent<PlayerPickup>().carriedObject == collision.gameObject))
                {
                    Player.GetComponent<PlayerPickup>().Drop();
                }
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<GameEnd>().GameOver(3);
            }
        }
    }
}
