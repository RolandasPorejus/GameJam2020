using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    GameObject mainCamera;
    GameObject player;
    GameObject carryPosition;
    GameObject carriedObject;
    GameObject pickupText;
    GameObject dropText;
    public float pickupDistance;
    bool carrying;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        carryPosition = GameObject.Find("CarryPosition");
        pickupText = GameObject.Find("PickupText");
        dropText = GameObject.Find("DropText");
        player = GameObject.Find("Player");

        pickupText.SetActive(false);
        dropText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        int x_center = Screen.width / 2;
        int y_center = Screen.height / 2;

        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x_center, y_center));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject selectedObject = hit.transform.gameObject;
            if (selectedObject.tag == "Carry" && Vector3.Distance(mainCamera.transform.position, selectedObject.transform.position) < pickupDistance)
            {
                pickupText.SetActive(true);
            }
            else
            {
                pickupText.SetActive(false);
            }
        }
        else {
            pickupText.SetActive(false);
        }

        if (carrying) {
            pickupText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carrying)
            {
                Drop();
                
            }
            else
            {
                carriedObject = hit.transform.gameObject;
                Pickup(carriedObject);
            }
        }

        if (carrying)
        {
            carriedObject.transform.position = carryPosition.transform.position;
            carriedObject.transform.rotation = carryPosition.transform.rotation;
            carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void Pickup(GameObject carriedObject)
    {
        carrying = true;
        pickupText.SetActive(false);
        dropText.SetActive(true);
        carriedObject.GetComponent<Rigidbody>().useGravity = false;
        carriedObject.transform.position = carryPosition.transform.position;
    }

    void Drop()
    {
        carrying = false;
        dropText.SetActive(false);
        carriedObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
