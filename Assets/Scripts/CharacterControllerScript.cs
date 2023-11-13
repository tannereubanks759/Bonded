using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterControllerScript : MonoBehaviour
{
    //movement variables
    float horizontal;
    float vertical;
    Vector3 moveInput;
    Vector3 moveDirection;
    Vector3 velocity;
    public float moveSpeed;
    private CharacterController controller;
    public float jumpForce;
    private float defaultSpeed;
    private float sprintSpeed;
    
    //look variables
    float mouseX, mouseY, multiplier = .01f, xRotation, yRotation;
    public float senseX, senseY;
    private Camera mainCamera;

    //keybinds
    public KeyCode jump = KeyCode.Space;
    public KeyCode sprint = KeyCode.LeftShift;
    public KeyCode flashlight = KeyCode.F;
    public KeyCode pistol = KeyCode.Alpha1;
    
    public GameObject flashlightObj;
    public GameObject pistolObj;

    public bool isPaused = false;

    //Pickup Object Variables
    public bool hasFlashlight = false;
    public bool hasGun = false;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        CursorDisable();
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        defaultSpeed = moveSpeed;
        sprintSpeed = moveSpeed * 1.5f;

        isPaused = false;
        flashlightObj.SetActive(false);
        pistolObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            //movement
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            if (controller.isGrounded && Input.GetKey(jump))
            {
                velocity.y = jumpForce;
            }
            else
            {
                velocity.y += -9.81f * Time.deltaTime;
            }
            moveDirection = transform.forward * vertical + transform.right * horizontal;

            controller.SimpleMove(moveDirection.normalized * moveSpeed);
            controller.Move(velocity * Time.deltaTime);

            //looking
            mouseX = Input.GetAxisRaw("Mouse X");
            yRotation += mouseX * senseX * multiplier;
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        

        

        //Sprinting
        if (Input.GetKey(sprint))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = defaultSpeed;
        }

        if (Input.GetKeyDown(flashlight) && hasFlashlight)
        {
            if (flashlightObj.activeSelf)
            {
                flashlightObj.SetActive(false);
            }
            else
            {
                flashlightObj.SetActive(true);
            }
        }
        if (Input.GetKeyDown(pistol) && hasGun)
        {
            if (pistolObj.activeSelf)
            {
                pistolObj.SetActive(false);
            }
            else
            {
                pistolObj.SetActive(true);
            }
        }
    }
    public void CursorDisable() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CursorEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PauseCharacterMovement(bool value)
    {
        isPaused = value;
        if (value == true)
        {
            FlashlightLook.isPaused = true;
        }
        else
        {
            FlashlightLook.isPaused = false;
        }
    }
    
}
