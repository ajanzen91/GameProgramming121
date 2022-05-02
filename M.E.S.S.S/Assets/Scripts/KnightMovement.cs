using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public MESSSui _ui;

    //Player stats
    public int _hp;
    public Gun _activeGun;
    //public Gun _pistol;
    public bool _hasRedKey;
    public bool _hasGreenKey;
    public bool _hasBlueKey;
    public float _jumpHeight = 5f;

    void Start()
    {
        //Declare initial variable states and/or get references to gameObjects
        _fpsCamera = Camera.main;
        _controller = GetComponent<CharacterController>();
        //_ray = new Ray();
        Cursor.lockState = CursorLockMode.Locked;
        _rotationSpeed = 7f;
        _xRotation = _yRotation = 0f;
        _hasBlueKey = _hasGreenKey = _hasRedKey = false;
        //_pistol.enabled = false;
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
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //SwapWeapons();
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

    //private void SwapWeapons()
    //{
    //    if (_shotgun.enabled == true)
    //    {
    //        _shotgun.enabled = false;
    //        _pistol.enabled = true;
    //    }
    //    else if(_pistol.enabled == true)
    //    {
    //        _pistol.enabled = false;
    //        _shotgun.enabled = true;
    //    }
    //}

    public void AddHealth(int amount)
    {
        _hp += amount;
        if (_hp >= 100)
        {
            _hp = 100;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Card")
        {
            if (collision.GetComponent<Card>()._doorNumber == 1)
            {
                _hasRedKey = true;
                _ui._redKey.enabled = true;
            }
            else if (collision.GetComponent<Card>()._doorNumber == 2)
            {
                _hasGreenKey = true;
                _ui._greenKey.enabled = true;
            }
            else if (collision.GetComponent<Card>()._doorNumber == 3)
            {
                _hasBlueKey = true;
                _ui._blueKey.enabled = true;
            }
        }
        else if (collision.tag == "Enemy")
        {
            _hp -= collision.GetComponent<Entity>()._eData.damage;
        }

        if (_hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
