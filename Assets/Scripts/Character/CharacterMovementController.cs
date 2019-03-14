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

    private float horizontalAxisRaw;

    private bool isLookingRight = true;

    private Character character
    {
        get
        {
            return STF.GameManager.Character;
        }
    }

    private void Start()
    {
        STF.InputController.RegisterKeyAction(MyKeyCode.Jump, true, Jump);
    }

    private void Update()
    {
        SetInputs();
        CheckIfAnyMovementButtonIsPressed();
        AddSpeedIfButtonPressed();
        CheckForGround();
        SetAnimator();
        SetLookDirection();
    }

    private void SetLookDirection()
    {
        bool isPushing = character.AnimatorController.CurrentState == AnimationState.Push;

        if (isPushing) // temp solution
        {
            isLookingRight = true;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            return;
        }

        if(horizontalAxisRaw == -1 && isLookingRight)
        {
            isLookingRight = false;
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if(horizontalAxisRaw == 1 && !isLookingRight)
        {
            isLookingRight = true;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    private void SetAnimator()
    {
        bool isPushing = character.AnimatorController.CurrentState == AnimationState.Push;

        if (isPushing)
        {
            return;
        }

        if (horizontalAxisRaw != 0)
        {
            character.AnimatorController.SetState(AnimationState.Walk);
        }
        else
        {
            character.AnimatorController.SetState(AnimationState.Idle);
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
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, GroundDistance);
        //Debug.DrawLine(transform.position, (Vector2)transform.position + (Vector2.down * GroundDistance));

        if(hits.Length == 0)
        {
            isTouchingGround = false;
        }
        else
        {
            for (int i = 0; i < hits.Length; i++)
            {
                bool touch = false;
                if (hits[i].collider.CompareTag(groundTag))
                {
                    touch = true;
                }
                isTouchingGround = touch;
            }
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

    private void Jump()
    {
        if (isTouchingGround)
        {
            RigidBody.AddForce(vectorUp * JumpPower, ForceMode2D.Impulse);
        }
    }

    private void AddSpeedIfButtonPressed()
    {
        if (!isMovementEnabled)
        {
            return;
        }

        //todo: ogarnąć dodawanie prędkości

        horizontalAxisRaw = STF.InputController.GetHorizontalAxisRaw();
        Vector2 forceVector = new Vector2(horizontalAxisRaw, 0) * Speed;
        RigidBody.AddForce(forceVector);
    }
}