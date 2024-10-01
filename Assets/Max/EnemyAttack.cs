using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackDamage;// default was 10
    public float attackCooldown = 1.5f; // default was 1.5
    private float timeSinceLastAttack = 0f;
    public bool canAttack = false;
    public PlayerHealth playerHealth;

   

    private void Awake()
    {
        // Find the player health component in the scene
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in playerObjects)
        {
            if (player.GetComponent<PlayerHealth>() != null)
            {
                playerHealth = player.GetComponent<PlayerHealth>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

       
        timeSinceLastAttack += Time.deltaTime;

        // Set the attack condition
        canAttack = timeSinceLastAttack > attackCooldown;
    }

    private void OnCollisionStay(Collision collision)
    {
        // Check for collision with the player
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            AttackPlayer();
        }
        // Check for collision with other enemies
        else if (collision.gameObject.CompareTag("Enemy") && canAttack)
        {
            AttackEnemy(collision.gameObject);
        }
    }

    private void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.Takedamage(attackDamage);
            //Debug.Log("Attacking Player! Damage: " + attackDamage);
            ResetAttack();
        }
    }

    private void AttackEnemy(GameObject enemy)
    {
        EnemyStats enemyHealth = enemy.GetComponent<EnemyStats>(); // Ensure you have an EnemyHealth script
        if (enemyHealth != null)
        {
            enemyHealth.Takedamage(attackDamage); // Adjust for enemy's health class
            //Debug.Log("Attacking Enemy! Damage: " + attackDamage);
            ResetAttack();
        }
    }

    private void ResetAttack()
    {
        timeSinceLastAttack = 0f; // Reset the attack timer
    }
}
