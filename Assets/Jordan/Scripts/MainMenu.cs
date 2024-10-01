using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject start;
    public GameObject settings;
    public GameObject HowtoPlay;
    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);
        settings.SetActive(false);
        HowtoPlay.SetActive(false);


    }

    // Update is called once per frame
   
    public void SettingsMenu()
    {
        settings.SetActive(true);
        start.SetActive(false);
    }

    public void BackSettings()
    {
        settings.SetActive(false);
        HowtoPlay.SetActive(false);
        start.SetActive(true);
    }

    public void HowToPlay()
    {
        start.SetActive(false);
        HowtoPlay.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {

    }

}
