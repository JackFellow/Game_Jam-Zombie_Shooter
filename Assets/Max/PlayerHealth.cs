using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }


    public float maxHealth = 100f;
    public float currentHealth;

    //At the moment i have done the ammo adding in player health
    //public int totalAmmo =0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Takedamage(float dam)
    {
        currentHealth -= dam;
        //Debug.Log($"{currentHealth}");
        //Debug.Log("The player health is:" + currentHealth + "player has taken " + dam + "damage");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within bounds
        //healthImage.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            //if the players health is 0 they are destoyed and the game manager is notified
            currentHealth = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //AudioManager.instance.musicSource.Stop();
            //healthImage.fillAmount = 0;
            // Destroy(gameObject);
        }

    }
    /*
    public void AddAmmo(int amount)
    {
        //Debug.Log("Current ammo  before adding ammo is :" + totalAmmo);
        totalAmmo += amount;
        Debug.Log("Ammo added: " + amount + ". Total ammo: " + totalAmmo);
    }
    */
}
