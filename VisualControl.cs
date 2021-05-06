using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class VisualControl : MonoBehaviour
{

    //visual variables
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    Vector2 rotation = new Vector2 (0, 0);
	public float speed = 3;
    float cameraPitch = 0.0f;
    float velocityY = 0.0f;

    //visual/movement controls
    CharacterController controller = null;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    //calls movement controls
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    //this function controls the mouse movements
    //visual control componments
    //author Acacia Developer
    //YouTube
    void UpdateMouseLook()
    {
        rotation.y += Input.GetAxis ("Mouse X");
		rotation.x += -Input.GetAxis ("Mouse Y");
		transform.eulerAngles = (Vector2)rotation * speed;
        rotation.x = Mathf.Clamp(rotation.x, -30.0f, 30.0f);
        Cursor.lockState = CursorLockMode.Locked;



    }


    //functions controls the character movement with WASD keys
    //author Acacia Developer
    //YouTube
    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if(controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;
		
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);


    }

 
}