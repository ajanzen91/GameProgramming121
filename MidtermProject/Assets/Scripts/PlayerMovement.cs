using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed;
    public float _walkSpeed;
    public float _runSpeed;

    public float Gravity = -9.81f; //acceleration of gravity
    public float _jumpHeight;
    private bool _groundedPlayer;
    private Vector3 _velocity, _inertia;

    private CharacterController _controller; //references Character Controller component
    private Animator _animator; //references Animator component
    public PlayerStats _stats;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>(); //must use GetComponentInChildren because our model is a child of the Player game object, in this case
    }

    private void Update()
    {
        Movement(); //see function on line 45


        if (Input.GetButtonDown("Jump") && _groundedPlayer) //predefined jump in Unity-- paired with space bar
        {
            Jump(); //defined on line 94
        }

        _velocity.y += Gravity * Time.deltaTime; //setting velocity in the y direction to the acceleration of gravity in relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); //movement based on velocity

        if (Input.GetKeyDown(KeyCode.Mouse0)) //when the left mouse button is clicked
        {
            Attack(); //start coroutine that causes the attack animation
        }
    }

    private void Movement() //called on line 27 in Update()
    {
        _groundedPlayer = _controller.isGrounded; //was the character touching the ground during the last frame? Accessing character controller's isGrounded property
        if (_groundedPlayer && _velocity.y <= 0)
        {
            _animator.SetLayerWeight(_animator.GetLayerIndex("Jump"), 0);
            _velocity.y = 0f; //if the character was grounded in the last frame and is now moving in a negative velocity (falling down), set the velocity (speed and direction) to zero
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //predefined axes in Unity linked to WASD controlls
        move = transform.TransformDirection(move); //changes direction 

        if(_velocity.y >= -3f && _velocity.y <= 3f)
        {
            JumpFloat();
        }
        else if(_velocity.y < -3f && !_groundedPlayer)
        {
            JumpFall();
        }

        if (_groundedPlayer)
        {
            _inertia = move;
            _controller.Move(move * Time.deltaTime * _moveSpeed);
        }
        else
        {
            _controller.Move(_inertia * Time.deltaTime * _moveSpeed);
        }    

        _velocity.y += Gravity * Time.deltaTime; //setting velocity in the y direction to the acceleration of gravity in relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); //movement based on velocity

        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) //if the character is moving AND the left shift key is not pressed, use the walking speed
        {
            if (move.z > 0)
            {
                Walk(); //defined on line 76
            }
            else
            {
                WalkBackwards();
            }
        }
        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) //if the character is mpoving and the left shift key IS pressed, use the running speed
        {
            if (move.z > 0)
            {
                Run(); //defined on line 83
            }
            else
            {
                RunBackwards();
            }
        }
        else if (move == Vector3.zero) //if the character is not moving, stand in idle
        {
            Idle(); //defined on line 89
        }

    }

    private void Walk()
    {
        _moveSpeed = _walkSpeed; //set my movement to walking speed
        _animator.SetFloat("PlayerMotion", 0.75f, 0.1f, Time.deltaTime);
        //_animator.SetFloat("KnightMovement", 0.5f, 0.1f, Time.deltaTime); //SetFloat sends float values to animator to create transitions in the blending tree (called KnightMovement)
        //second value is dampTime-- the amount of time it takes to change the float to .5.
    }

    private void WalkBackwards()
    {
        _moveSpeed = _walkSpeed;
        _animator.SetFloat("PlayerMotion", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        _moveSpeed = _runSpeed; //set my movement to running speed
        _animator.SetFloat("PlayerMotion", 1f, 0.1f, Time.deltaTime);
    }

    private void RunBackwards()
    {
        _moveSpeed = _runSpeed;
        _animator.SetFloat("PlayerMotion", 0.25f, 0.1f, Time.deltaTime);
    }

    private void Idle()
    {
        _moveSpeed = 0;
        _animator.SetFloat("PlayerMotion", 0f, 0.1f, Time.deltaTime); //blending tree value of 0 equates to idle animation
    }

    private void Jump()
    {
        _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Gravity);//change velocity to reflect a jumping behavior
        _animator.SetLayerWeight(_animator.GetLayerIndex("Jump"), 1);
        _animator.SetFloat("Jump", 0.333f, 0.1f, Time.deltaTime);
        _groundedPlayer = false;
    }

    private void JumpFloat()
    {
        _animator.SetFloat("Jump", 0.666f, 0.25f, Time.deltaTime);
    }

    private void JumpFall()
    {
        _animator.SetFloat("Jump", 1f, 0.25f, Time.deltaTime);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Jump"), 0);
    }

    private void Attack()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack"), 1); //attack layer is being accessed in it's entirety-- accesses the avatar mask to only utilize certain parts of the body
        _animator.SetTrigger("Attack"); //uses trigger called Atatck
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 0); //...before disabling the avatar mask, and returning movement to the entire body 
        _stats._activeSpell._remainingCasts--;
    }
}

