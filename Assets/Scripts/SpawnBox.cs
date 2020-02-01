using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public GameObject spawnedObject;
    public float spawnFrequency;
    public float secondGap;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (DifficultySystem.Difficulty > 0)
        {
            secondGap = spawnFrequency / DifficultySystem.Difficulty;
            if (timer > secondGap)
            {
                Instantiate(spawnedObject, transform.position, Quaternion.identity);
                timer = 0.0f;
            }
        }
    }
}
