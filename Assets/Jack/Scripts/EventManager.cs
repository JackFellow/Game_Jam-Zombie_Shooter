using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public bool isPaused = false;

    void Awake()
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

    #region Weapons
    public event Action onShoot;
    public void Shoot()
    {
        Debug.Log("Fired");
        if (onShoot != null)
        {
            onShoot();
        }
    }

    public event Action<int> onSwitch;
    public void Switch(int index)
    {
        Debug.Log("Switch");

        if (onSwitch != null)
        {
            onSwitch(index);
        }
    }

    public event Action<int> onReload;
    public void Reload(int amount)
    {
        if (onReload != null)
        {
            onReload(amount);
        }
    }

    #endregion
}
