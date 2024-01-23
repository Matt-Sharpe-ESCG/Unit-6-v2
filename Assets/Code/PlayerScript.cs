using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Unity Refrences
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public LayerMask groundMask;
    Animator anim;

    // Float Variables
    public float groundDistance = 0.4f;   
    public float speed;
    public float turnSmoothTime = 0.1f;   
    public float gravity = -9.81f;
    public float jumpFactor;
    float turnSmoothVelocity;

    // Additional Variables
    Vector3 velocity;
    bool isGrounded;
    
    void Start()
    { 
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movement Inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        // Animation Variables
        anim.SetBool("Walk", false);
        anim.SetBool("Slash", false);
        anim.SetBool("Crouch", false);
        anim.SetBool("Run", false);
        anim.SetBool("Block", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Kick", false);
        anim.SetBool("Slash 2", false);
        anim.SetBool("Death", false);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Basic 2 Axis Movement
        speed = 12f;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            controller.Move(velocity * Time.deltaTime);
            anim.SetBool("Walk", true);
        }

        // Sprint Mechanic
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 36f;
            anim.SetBool("Run", true);
        }

        // Crouch Mechanic
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", true);
        }

        // Sword Slash Mechanic
        if (Input.GetKey(KeyCode.Return))
        {
            anim.SetBool("Slash", true);
        }

        // Sword Underslash
        if (Input.GetKey(KeyCode.Backspace))
        {
            anim.SetBool("Slash 2", true);
        }

        // Jump Mechanic
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            anim.SetBool("Jump", true);
        }

        // Block Mechanic
        if (Input.GetKey(KeyCode.B))
        {
            anim.SetBool("Block", true);
        }

        // Kick Mechanic
        if (Input.GetKey(KeyCode.K))
        {
            anim.SetBool("Kick", true);
        }

        // Suicide Mechanic
        if (Input.GetKey(KeyCode.L))
        {
            anim.SetBool("Death", true);
        }
    }
}
