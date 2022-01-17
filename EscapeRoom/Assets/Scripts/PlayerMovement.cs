using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2f;

    [SerializeField] private Transform orientation;

    [Header("Movement")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float movementMult = 10f;
    [SerializeField] private float airMultiplier = 0.1f;
    [Header("Sprinting")]
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float sprintSpeed = 6f;
    [SerializeField] private float acceleration = 10f;
    [Header("KeyBinds")]
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;
    [Header("KeyBinds")]
    float groundDrag = 6f;

    float horizontalMovement;
    float verticalMovement;
    [Header("Ground Detection")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] Transform groundCheck;
    bool isGrounded;

    public float GravityDrag = -15;

    Vector3 moveDir;
    Vector3 slopeMoveDir;

    Rigidbody rb;

    RaycastHit slopeHit;
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        MyInput();
        ControlDrag();
        ControlSpeed();
        slopeMoveDir = Vector3.ProjectOnPlane(moveDir, slopeHit.normal);
        rb.AddForce(orientation.up * GravityDrag, ForceMode.Acceleration);
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        moveDir = orientation.forward * verticalMovement + orientation.transform.right * horizontalMovement;
    }
    private void MovePlayer()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDir.normalized * speed * movementMult, ForceMode.Acceleration);
        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDir.normalized * speed * movementMult, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDir.normalized * speed * movementMult * airMultiplier, ForceMode.Acceleration);
        }

    }
    private void ControlSpeed()
    {
        if (Input.GetKey(sprintKey) && isGrounded)
        {
            speed = Mathf.Lerp(speed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            speed = Mathf.Lerp(speed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    private void ControlDrag()
    {
        rb.drag = groundDrag;
    }
}
