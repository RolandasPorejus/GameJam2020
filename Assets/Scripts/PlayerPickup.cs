using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    GameObject mainCamera;
    GameObject player;
    GameObject carryPosition;
    GameObject pickupText;
    GameObject dropText;
    public float pickupDistance;
    public float carryDistance;
    public float smooth;

    public GameObject carriedObject;
    public bool carrying;

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

        GameObject selectedObject = null;
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x_center, y_center));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            selectedObject = hit.transform.gameObject;
            if ((selectedObject.tag == "Box" || selectedObject.tag == "Key") && Vector3.Distance(mainCamera.transform.position, selectedObject.transform.position) < pickupDistance)
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

                if (selectedObject != null && (selectedObject.tag == "Box" || selectedObject.tag == "Key"))
                {
                    carriedObject = hit.transform.gameObject;
                    Pickup(carriedObject);
                }
            }
        }

        if (carrying)
        {
            Carry();
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

    public void Drop()
    {
        carrying = false;
        dropText.SetActive(false);
        carriedObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }

    void Carry()
    {
        //carriedObject.transform.position = carryPosition.transform.position;
        //carriedObject.transform.rotation = carryPosition.transform.rotation;
        //carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, mainCamera.transform.position 
            + mainCamera.transform.forward * carryDistance, Time.deltaTime * smooth);
        //carriedObject.transform.rotation = Quaternion.identity;
    }
}
