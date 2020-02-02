using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogRotation : MonoBehaviour
{
    public float speed;
    public Vector3 m_EulerAngleVelocity;
    private bool soundStarted;

    // Start is called before the first frame update
    void Start()
    {
        soundStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DifficultySystem.Difficulty > 0)
        {
            if (!soundStarted)
            {
                GetComponent<AudioSource>().Play(0);
            }
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * DifficultySystem.Difficulty);
            GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * deltaRotation);
        }
    }
}
