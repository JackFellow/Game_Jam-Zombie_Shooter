using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{


    public string name;        // Name of the zombie type for easy identification
    public float moveSpeed;        // Movement speed of the zombie
    private Vector3 targetPosition = Vector3.zero;

    public float attackDamage;      // Damage dealt by the zombie
    public float attackCooldown;
    private float timeSinceLastAttack = 0f;
    public bool canAttack;
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {

        // Calculate the direction towards (0, 0, 0)
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Move the enemy towards the target position
        transform.position += direction * moveSpeed * Time.deltaTime;

    }
    public void Takedamage ( float dam)
    {
        currentHealth -= dam;

        currentHealth= Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth < 0 )
        {
            currentHealth = 0;

        }
    }
}
