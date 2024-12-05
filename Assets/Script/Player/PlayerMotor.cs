using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool IsGrounded { get; private set; }
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    private bool lerpCrouch;
    private bool crouching;
    private bool sprinting;
    private float crouchTimer;

    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }

        if (IsGrounded)
        {
            animator.SetBool("Isjumping", false);
        }
    }

    public void Crouch()
    {
        lerpCrouch = true;
        crouching = !crouching;
        crouchTimer = 0;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 8;
            animator.SetBool("Isrunning", true);
        }
        else
        {
            speed = 5;
            animator.SetBool("Iswalking", true);
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (IsGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("Iswalking", true);
        }
        else
        {
            animator.SetBool("Iswalking", false);
        }

        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            animator.SetBool("Isjumping", true);
        }
    }

    public void Fall()
    {
        if (!IsGrounded)
        {
            playerVelocity.y += gravity * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}
