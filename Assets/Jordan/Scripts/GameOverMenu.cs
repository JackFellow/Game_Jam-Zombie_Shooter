using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{

    public GameObject GameOverScreen;
    public GameObject HUD;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
        HUD.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isDead)
        {
            GameOver();
        }
        else
        {
            GameOverScreen.SetActive(false);
        }
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        
    }
}
