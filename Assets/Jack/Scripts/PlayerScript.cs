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
    }

    private void OnDisable()
    {
        look.Disable();

        fire.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnLook();
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
}
