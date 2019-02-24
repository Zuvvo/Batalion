﻿using System;
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

    public CharacterEffects MovementEffects;


    private bool isLeftHeld;
    private bool isRightHeld;
    private bool isUpHeld;
    private bool isDownHeld;
    private bool isSpaceHeld;
    private bool isTouchingGround;

    private bool isMovementEnabled = true;

    private Vector2 vectorUp = Vector2.up;
    private string groundTag = "Ground";

    private void Update()
    {
        SetInputs();
        CheckIfAnyMovementButtonIsPressed();
        AddSpeedIfButtonPressed();
        if (!isTouchingGround)
        {
            CheckForGround();
        }
    }

    private void CheckIfAnyMovementButtonIsPressed()
    {

    }

    public void SetMovementActive(bool value)
    {
        isMovementEnabled = value;
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
        isLeftHeld = MyKeyCode.Left.IsKeyHeld(); //Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        isRightHeld = MyKeyCode.Right.IsKeyHeld(); //Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        isUpHeld = MyKeyCode.Up.IsKeyHeld();//Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        isDownHeld = MyKeyCode.Down.IsKeyHeld();  //Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        isSpaceHeld = MyKeyCode.Jump.IsKeyHeld(); //Input.GetKey(KeyCode.Space);
    }

    private void AddSpeedIfButtonPressed()
    {
        if (!isMovementEnabled)
        {
            return;
        }

        if (isSpaceHeld && isTouchingGround)
        {
            isTouchingGround = false;
            RigidBody.AddForce(vectorUp * JumpPower, ForceMode2D.Impulse);
        }

        //todo: ogarnąć dodawanie prędkości

        if (isLeftHeld)
        {
            RigidBody.velocity += Vector2.left * Time.deltaTime * Speed;
        }
        else if (isRightHeld)
        {
            RigidBody.velocity += Vector2.right * Time.deltaTime * Speed;
        }
        else if (isUpHeld)
        {
            RigidBody.velocity += Vector2.up * Time.deltaTime * Speed;
        }
        else if (isDownHeld)
        {
            RigidBody.velocity += Vector2.down * Time.deltaTime * Speed;
        }
    }
}