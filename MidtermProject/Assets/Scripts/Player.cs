using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float Gravity = -9.81f;
    private float _walkSpeed = 1f, _runSpeed = 3f, _jumpSpeed = 3f;
    private float _moveSpeed;
    private Vector3 _velocity, horizMove;
    private bool _onGround;
    private int health = 5, score = 0;

    private Animator _animator;
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        Console.WriteLine("Score 5 points before you lose your 5 HP!");
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _onGround = _controller.isGrounded;

        if (_onGround && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        handleInput();

        //implement movement

    }

    void handleInput()
    {
        //2d movement
        horizMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        horizMove = transform.TransformDirection(horizMove);
        _controller.Move(horizMove * Time.deltaTime);

        //jump input
        if (Input.GetButtonDown("Jump") && _onGround)
        {
            _velocity.y += Mathf.Sqrt(_jumpSpeed * Gravity);
        }

        //Running?
        //if (horizMove != Vector3.zero)
        //{
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        _moveSpeed = _runSpeed;

        //        if (horizMove.z > 0)
        //        {
        //            _animator.SetFloat("MovementLayer", 1f, 0.1f, Time.deltaTime);
        //        }
        //        else if (horizMove.z < 0)
        //        {
        //            _animator.SetFloat("MovementLayer", 0f, 0.1f, Time.deltaTime);
        //        }
        //        else
        //        {
        //            _animator.SetFloat("MovementLayer", 0.5f, 0.1f, Time.deltaTime);
        //        }
        //    }
        //    else
        //    {
        //        //_moveSpeed = _walkSpeed;

        //        if (horizMove.z > 0)
        //        {
        //            _animator.SetFloat("MovementLayer", 0.75f, 0.1f, Time.deltaTime);
        //        }
        //        else if (horizMove.z < 0)
        //        {
        //            _animator.SetFloat("MovementLayer", 0.25f, 0.1f, Time.deltaTime);
        //        }
        //        else
        //        {
        //            _animator.SetFloat("MovementLayer", 0.5f, 0.1f, Time.deltaTime);
        //        }
        //    }
        //}

        if (horizMove != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) //if the character is moving AND the left shift key is not pressed, use the walking speed
        {
            _moveSpeed = _walkSpeed; //set my movement to walking speed
            _animator.SetFloat("MovementLayer", 0.75f, 0.1f, Time.deltaTime);
        }
        else if (horizMove != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) //if the character is mpoving and the left shift key IS pressed, use the running speed
        {
            _moveSpeed = _runSpeed; //set my movement to running speed
            _animator.SetFloat("MovementLayer", 1f, 0.1f, Time.deltaTime);
        }
        else if (horizMove == Vector3.zero) //if the character is not moving, stand in idle
        {
            _animator.SetFloat("MovementLayer", .5f, 0.1f, Time.deltaTime);
        }


        _velocity.y += Gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
