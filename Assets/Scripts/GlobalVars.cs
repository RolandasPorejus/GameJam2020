using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySystem : MonoBehaviour
{
    public static int Difficulty = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void IncreaseDifficulty() {
        Difficulty++;
        if (GameObject.FindGameObjectsWithTag("Key").Length == Difficulty) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<GameEnd>().Victory();
        }
    }
}
