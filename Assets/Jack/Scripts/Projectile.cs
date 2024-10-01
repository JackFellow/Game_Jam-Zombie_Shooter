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
        if (Mathf.Abs(prefab.transform.position.x) > despawnRadius || Mathf.Abs(prefab.transform.position.y) > despawnRadius)
        {
            Destroy(prefab);
        }
    }
}
