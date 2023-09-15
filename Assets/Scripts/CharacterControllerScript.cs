using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        CursorDisable();
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        defaultSpeed = moveSpeed;
        sprintSpeed = moveSpeed * 2f;
    }

    // Update is called once per frame
    void Update()
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
        mouseY = Input.GetAxisRaw("Mouse Y");
        yRotation += mouseX * senseX * multiplier;
        xRotation -= mouseY * senseY * multiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

        

        //Sprinting
        if (Input.GetKey(sprint))
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = defaultSpeed;
        }
    }
    public void CursorDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CursorEnable()
    {

    }
}
