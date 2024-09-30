using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public GameObject prefab;

    public GameObject projectile;

    public int ammo;
    public int maxAmmo;

    public float fireRate;

    public float speed;
}
