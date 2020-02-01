using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDestroyer : MonoBehaviour
{
    GameObject Player;
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
        if (collision.gameObject.tag == "Key")
        {
            if (Player.GetComponent<PlayerPickup>().carrying && (Player.GetComponent<PlayerPickup>().carriedObject == collision.gameObject))
            {

                Player.GetComponent<PlayerPickup>().Drop();
            }
            Destroy(collision.gameObject);
            Player.GetComponent<GameEnd>().GameOver(1);
        }
        else if (collision.gameObject.tag == "Box") {
            if (Player.GetComponent<PlayerPickup>().carrying && (Player.GetComponent<PlayerPickup>().carriedObject == collision.gameObject)) {
                Player.GetComponent<PlayerPickup>().Drop();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GameEnd>().GameOver(2);
        }
    }
}
