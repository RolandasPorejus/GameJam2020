using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketSystem : MonoBehaviour
{
    GameObject Player;
    bool keyInside = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key" && !keyInside)
        {
            if (Player.GetComponent<PlayerPickup>().carrying && (Player.GetComponent<PlayerPickup>().carriedObject == collision.gameObject))
            {
                Player.GetComponent<PlayerPickup>().Drop();
            }
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.transform.rotation = transform.rotation;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //collision.gameObject.tag = "Untagged";
            keyInside = true;
            DifficultySystem.IncreaseDifficulty();
        }
    }
}
