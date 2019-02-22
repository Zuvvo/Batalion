using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public float Speed = 10;
    public float JumpPower = 2;
    public float GroundDistance;

    public BoxCollider2D Collider;
    public Rigidbody2D RigidBody;


    private bool isLeftPressed;
    private bool isRightPressed;
    private bool isUpPressed;
    private bool isDownPressed;
    private bool isSpacePressed;
    private bool isTouchingGround;

    private Vector2 vectorUp = Vector2.up;
    private string groundTag = "Ground";

    private void Update()
    {
        SetInputs();
        AddSpeedIfButtonPressed();
        if (!isTouchingGround)
        {
            CheckForGround();
        }
    }

    private void CheckForGround()
    {
        //todo: ogarnąć layerMask i castowanie spod nóg a nie z środka (transform.position)
        //layer postaci to "ignore raycast" dlatego nie łapie, ale musi mieć włączone łapanie raycastów jak będą do niego przecwnicy strzelać
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, GroundDistance);
        Debug.DrawLine(transform.position, (Vector2)transform.position + (Vector2.down * GroundDistance));
        if(hit.collider == null)
        {
            return;
        }

        if (hit.collider.CompareTag(groundTag))
        {
            isTouchingGround = true;
        }
    }

    private void SetInputs()
    {
        isLeftPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        isRightPressed = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        isUpPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        isDownPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        isSpacePressed = Input.GetKey(KeyCode.Space);
    }

    private void AddSpeedIfButtonPressed()
    {
        if (isSpacePressed && isTouchingGround)
        {
            isTouchingGround = false;
            RigidBody.AddForce(vectorUp * JumpPower, ForceMode2D.Impulse);
        }

        if (isLeftPressed)
        {
            RigidBody.velocity += Vector2.left * Time.deltaTime * Speed;
        }
        else if (isRightPressed)
        {
            RigidBody.velocity += Vector2.right * Time.deltaTime * Speed;
        }
        else if (isUpPressed)
        {
            RigidBody.velocity += Vector2.up * Time.deltaTime * Speed;
        }
        else if (isDownPressed)
        {
            RigidBody.velocity += Vector2.down * Time.deltaTime * Speed;
        }
    }
}