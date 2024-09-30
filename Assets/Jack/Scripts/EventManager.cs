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

    #region Inputs
    public event Action onShoot;
    public void Shoot()
    {
        Debug.Log("Fired");
        if (onShoot != null)
        {
            onShoot();
        }
    }
    #endregion
}
