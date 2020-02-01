using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScene : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Restart);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
