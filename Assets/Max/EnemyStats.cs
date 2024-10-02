using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{


    public string name;        // Name of the zombie type for easy identification
    public float moveSpeed;        // Movement speed of the zombie
    private Vector3 targetPosition = Vector3.zero;
    int ammoToAdd = 5;
    //public PlayerHealth playerAmmo;


    //public bool canAttack;
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        /*
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in playerObjects)
        {
            if (player.GetComponent<PlayerHealth>() != null)
            {
                playerAmmo = player.GetComponent<PlayerHealth>();
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth<= 0)
        {
            Die();
        }

        // Calculate the direction towards (0, 0, 0)
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Move the enemy towards the target position
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position);

    }
    public void Takedamage ( float dam)
    {
        currentHealth -= dam;

        currentHealth= Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth < 0 )
        {
            currentHealth = 0;

            Die();

        }
    }

    

    private void Die()
    {
        //used to give player ammo
        float dropChance = Random.Range(0f, 1f);
        if (dropChance<= 0.5)
        {
            //playerAmmo.AddAmmo(ammoToAdd);
            EventManager.Instance.Reload(ammoToAdd);

        }
        Destroy(gameObject);
    }
}
