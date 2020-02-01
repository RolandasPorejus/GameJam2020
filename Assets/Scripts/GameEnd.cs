using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public bool Dead = false;

    GameObject BtnRestart;
    GameObject GameoverText;
    GameObject VictoryText;

    // Start is called before the first frame update
    void Start()
    {
        BtnRestart = GameObject.Find("btnRestart");
        GameoverText = GameObject.Find("GameoverText");
        VictoryText = GameObject.Find("VictoryText");

        BtnRestart.SetActive(false);
        GameoverText.SetActive(false);
        VictoryText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Victory() {
        BtnRestart.SetActive(true);
        VictoryText.SetActive(true);
    }

    public void GameOver(int variation) {
        Dead = true;
        GetComponent<BoxCollider>().size = new Vector3(GetComponent<BoxCollider>().size.x, GetComponent<BoxCollider>().size.y * 0.1f, GetComponent<BoxCollider>().size.z);

        switch (variation)
        {
            case 1:
                BtnRestart.SetActive(true);
                GameoverText.SetActive(true);
                GameoverText.GetComponent<Text>().text = "Uh oh you dropped a priceless spare part into acid! Impressive.";
                break;
            case 2:
                BtnRestart.SetActive(true);
                GameoverText.SetActive(true);
                GameoverText.GetComponent<Text>().text = "You melted in acid! Ouch.";
                break;
            default:
                BtnRestart.SetActive(true);
                GameoverText.SetActive(true);
                break;
        }

    }
}
