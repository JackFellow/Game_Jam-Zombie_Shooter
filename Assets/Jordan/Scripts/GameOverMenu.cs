using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{

    public GameObject GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
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
        Time.timeScale = 0f;
        
    }
}
