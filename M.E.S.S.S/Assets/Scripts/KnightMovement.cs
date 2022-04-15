using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    /***
     *CURRENT TASKS* 
     * Implement damage taking behavior for player and monkey
     ** Struct for player stats?
     * Implement UI
     ***/
    //player stats

    //Rotation variables
    public float _xRotation, _yRotation, _rotationSpeed;
    
    //planar movement variables
    private float _moveSpeed;
    public float _walkSpeed = 1f;
    public float _runSpeed = 5f;

    //Vertical movement variables
    public float Gravity = -9.81f;
    
    private bool _groundedPlayer;
    private Vector3 _velocity;

    //GameComponent variables
    private Camera _fpsCamera;
    private CharacterController _controller;

    //Player stats
    public int _hp = 100;
    private Gun _activeGun;
    private Gun[] _gun;
    public float _jumpHeight = 5f;

    void Start()
    {
        //Declare initial variable states and/or get references to gameObjects
        _activeGun = gameObject.GetComponent<Gun>();
        _fpsCamera = Camera.main;
        _controller = GetComponent<CharacterController>();
        //_ray = new Ray();
        Cursor.lockState = CursorLockMode.Locked;
        _rotationSpeed = 7f;
        _xRotation = _yRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    { 
        //Get Mouse position
        //_mouse = _fpsCamera.ScreenToViewportPoint(Input.mousePosition);

        
        TurnPlayer();
        Movement();
    }

    private void Movement()
    {
        //Prevent player from falling through the floor and double jumping
        _groundedPlayer = _controller.isGrounded;

        if (_groundedPlayer && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        //wasd/player movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);

        //Vertical movement
        _velocity.y += Gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        //Parse player input
        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            Jump();
        }

        //move character controller
        _controller.Move(move * Time.deltaTime * _moveSpeed);
    }

    private void Walk()
    {
        _moveSpeed = _walkSpeed;
    }

    private void Run()
    {
        _moveSpeed = _runSpeed;
    }

    private void Jump()
    {
        _velocity.y += Mathf.Sqrt(-_jumpHeight * Gravity); //change vertical velocity to reflect a jumping behavior
    }

    private void TurnPlayer()
    {
        //Get mouse position relative to screen (bottom left is 0,0)
        float InputX = Input.GetAxis("Mouse X");
        float InputY = Input.GetAxis("Mouse Y");
        
        //Change rotation amount based on given roration speed
        InputX *= _rotationSpeed;
        InputY *= _rotationSpeed;
        
        //Clamp vertical rotation and transform player object
        _xRotation += InputX;
        _yRotation += InputY;
        _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);
        _controller.transform.rotation = Quaternion.Euler(-_yRotation, _xRotation, 0);
    }
}
