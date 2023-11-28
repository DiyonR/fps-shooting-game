using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float currentSpeed;

    public float gravity = -0.5f;
    private float baseLineGravity;
    public float jumpSpeed = 0.8f;
    public float dodgeDistance = 7f;
    public float dodgeSpeed = 4f; 

    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;

    private bool dodgeOnCooldown = false;
    private float dodgeCooldown = 3.0f;
    private float dodgeCooldownTimer = 0.0f;

    private Vector3 dodgeStartPosition;
    private Vector3 dodgeTargetPosition;
    private float dodgeLerpTime;

    void Start()
    {
        baseLineGravity = gravity;
        currentSpeed = 10.0f;
    }

    void Update()
    {
        DodgeCooldown();

        // Regular movement
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * moveX +
               transform.up * gravity +
               transform.forward * moveZ;

        characterController.Move(move);

        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            gravity = baseLineGravity;
            gravity *= -jumpSpeed;
        }

        if (gravity > baseLineGravity)
        {
            gravity -= 2 * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Apply dodge movement
        if (dodgeLerpTime < 1.0f)
        {
            dodgeLerpTime += Time.fixedDeltaTime * dodgeSpeed;
            Vector3 newPosition = Vector3.Lerp(dodgeStartPosition, dodgeTargetPosition, dodgeLerpTime);
            characterController.Move(newPosition - transform.position);
        }
    }

    void DodgeCooldown()
    {
        if (dodgeOnCooldown)
        {
            dodgeCooldownTimer -= Time.deltaTime;

            if (dodgeCooldownTimer <= 0.0f)
            {
                dodgeOnCooldown = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!dodgeOnCooldown)
                {
                    Dodge();
                }
            }
        }
    }

    void Dodge()
    {
        dodgeStartPosition = transform.position;
        dodgeTargetPosition = transform.position + transform.forward * dodgeDistance;
        dodgeLerpTime = 0.0f;

        dodgeOnCooldown = true;
        dodgeCooldownTimer = dodgeCooldown;
    }
}







