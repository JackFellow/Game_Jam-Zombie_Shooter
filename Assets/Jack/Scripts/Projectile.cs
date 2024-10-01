using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;

    public float despawnRadius;

    public GameObject prefab;

    private void FixedUpdate()
    {
        if (Mathf.Abs(prefab.transform.position.x) > despawnRadius || Mathf.Abs(prefab.transform.position.y) > despawnRadius || Mathf.Abs(prefab.transform.position.z) > despawnRadius)
        {
            Destroy(prefab);
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyHealth = collision.gameObject.GetComponent<EnemyStats>(); // Ensure you have an EnemyHealth script
            enemyHealth.Takedamage(damage);
            
        }

        //Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("HitTrigger");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyHealth = collision.gameObject.GetComponent<EnemyStats>(); // Ensure you have an EnemyHealth script
            enemyHealth.Takedamage(damage);

        }

        Destroy(gameObject);
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyHealth = collision.gameObject.GetComponent<EnemyStats>(); // Ensure you have an EnemyHealth script
            enemyHealth.Takedamage(damage);
        }

        Destroy(gameObject);
    }
}
