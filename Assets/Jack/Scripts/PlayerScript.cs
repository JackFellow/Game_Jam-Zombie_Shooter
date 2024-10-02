using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    PlayerInputActions playerControls;

    public Camera mainCamera;

    private InputAction look;
    private InputAction fire;
    private InputAction scroll;
    private InputAction s1;
    private InputAction s2;
    private InputAction s3;

    Vector2 lookDirection;

   
    float verticalRotation = 0f;
    float horizontalRotation = 0f;

    public float mouseSensitivity = 100f;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        //mainCamera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        look = playerControls.Player.Look;
        look.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        scroll = playerControls.Player.Scroll;
        scroll.Enable();

        s1 = playerControls.Player.s1;
        s1.Enable();
        s1.performed += S1;

        s2 = playerControls.Player.s2;
        s2.Enable();
        s2.performed += S2;

        s3 = playerControls.Player.s3;
        s3.Enable();
        s3.performed += S3;
    }

    private void OnDisable()
    {
        look.Disable();

        fire.Disable();

        scroll.Disable();

        s1.Disable();

        s2.Disable();

        s3.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
            OnLook();
            Scroll();
        
       
    }

    void OnLook()
    {
        lookDirection = look.ReadValue<Vector2>();

        verticalRotation -= lookDirection.y * mouseSensitivity * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        horizontalRotation = lookDirection.x * mouseSensitivity * Time.deltaTime;

        transform.Rotate(0f, horizontalRotation, 0f);

        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        EventManager.Instance.Shoot();
    }

    void Scroll()
    {

        if (scroll.ReadValue<float>() > 0)
        {
            EventManager.Instance.Switch(--Inventory.Instance.weaponIndex);
        }
        else if (scroll.ReadValue<float>() < 0)
        {
            EventManager.Instance.Switch(++Inventory.Instance.weaponIndex);
        }
    }

    void S1(InputAction.CallbackContext context)
    {
        EventManager.Instance.Switch(0);
    }

    void S2(InputAction.CallbackContext context)
    {
        EventManager.Instance.Switch(1);
    }

    void S3(InputAction.CallbackContext context)
    {
        EventManager.Instance.Switch(2);
    }
}
