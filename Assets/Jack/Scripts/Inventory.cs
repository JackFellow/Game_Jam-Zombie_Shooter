using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

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

    Rigidbody rb;

    public Weapon[] Weapons;

    public GameObject SpawnLocation;

    Weapon currentWeapon;

    private void OnEnable()
    {
        EventManager.Instance.onShoot += Shoot;
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        if (Weapons != null)
        {
            currentWeapon = Weapons[0];
        }
    }

    public void Reload(int reloadAmmo)
    {
        currentWeapon.ammo += reloadAmmo;

        currentWeapon.ammo = Mathf.Clamp(currentWeapon.ammo, 0, currentWeapon.maxAmmo);
    }

    void Shoot()
    {
        --currentWeapon.ammo;

        GameObject projectile = Instantiate(currentWeapon.projectile, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
        rb = projectile.GetComponent<Rigidbody>();

        rb.velocity = projectile.transform.forward * currentWeapon.speed;
    }

    void SwitchWeapon()
    {

    }
}
