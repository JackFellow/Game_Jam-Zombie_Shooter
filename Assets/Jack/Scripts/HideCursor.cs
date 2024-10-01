using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //esc
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
