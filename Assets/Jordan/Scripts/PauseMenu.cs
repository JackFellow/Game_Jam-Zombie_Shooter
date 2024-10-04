using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pause;
    
    public GameObject hud;
    
   // public GameOverMenu gameOver;
    public static bool isPaused;
    bool begin;
    public static bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        hud.SetActive(true);
        pause.SetActive(false);
        isPaused = false; 
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead is true)
        {
           pause.SetActive(false);
        }
        else
        {
            if (begin)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (isPaused)
                    {
                        resumeGame();
                        // Debug.Log("paused2");
                    }

                    else
                    {
                        pasueGame();
                        //  Debug.Log("paused3");
                    }
                }
            }

       

      
    

    
            else
            {
                StartCoroutine(Play());
            }


       }
    }

    public IEnumerator Play()
    {
        Time.timeScale = 1f;
        yield return null;
        begin = true;

    }

    public void pasueGame()
    {


        hud.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        // Debug.Log("paused");


    }

    public void resumeGame()
    {
        pause.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;

    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Main Game");
        PlayerHealth.Instance.currentHealth = 100;
        
        
    }

   

    public void QuitGame()
    {
      
        PlayerHealth.Instance.currentHealth = 100;
        Time.timeScale = 0f;
        SceneManager.LoadScene("Jordan");
       
    }
}
