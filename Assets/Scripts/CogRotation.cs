using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogRotation : MonoBehaviour
{
    public float speed;
    public Vector3 m_EulerAngleVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DifficultySystem.Difficulty > 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * DifficultySystem.Difficulty);
            GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * deltaRotation);
        }
    }
}
