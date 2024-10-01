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

    public int weaponIndex = 0;

    bool canFire = true;

    private void OnEnable()
    {
        EventManager.Instance.onShoot += Shoot;
        EventManager.Instance.onReload += Reload;
        EventManager.Instance.onSwitch += SwitchWeapon;
    }

    private void OnDisable()
    {
        EventManager.Instance.onShoot -= Shoot;
        EventManager.Instance.onReload -= Reload;
        EventManager.Instance.onSwitch -= SwitchWeapon;
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
        if (canFire)
        {
            if (currentWeapon.ammo > 0 || currentWeapon.maxAmmo == -1)
            {
                StartCoroutine(ShootCooldown());

                --currentWeapon.ammo;

                GameObject projectile = Instantiate(currentWeapon.projectile, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
                rb = projectile.GetComponent<Rigidbody>();

                rb.velocity = projectile.transform.forward * currentWeapon.speed;
            }
        }
    }

    void SwitchWeapon(int index)
    {
        currentWeapon.prefab.SetActive(false);

        if (index >= Weapons.Length)
        {
            weaponIndex = 0;
            currentWeapon = Weapons[weaponIndex];
        }
        else if (index < 0)
        {
            weaponIndex = Weapons.Length - 1;
            currentWeapon = Weapons[weaponIndex];
        }
        else
        {
            weaponIndex = index;
            currentWeapon = Weapons[weaponIndex];
        }

        currentWeapon.prefab.SetActive(true);
    }

    IEnumerator ShootCooldown()
    {
        canFire = false;

        yield return new WaitForSeconds(currentWeapon.fireRate);

        canFire = true;
    }
}
