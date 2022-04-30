using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightMovement : MonoBehaviour
{
    /***
     *CURRENT TASKS* 
     * Implement damage taking behavior for player and monkey
     * Implement UI
     ***/

    //Rotation variables
    public float _rotationSpeed;
    private float _xRotation, _yRotation;

    //planar movement variables
    private float _moveSpeed;
    public float _walkSpeed = 1f;
    public float _runSpeed = 5f;

    //Vertical movement variables
    public float Gravity = -9.81f;
    private bool _groundedPlayer;
    private Vector3 _velocity;

    //Internal GameComponent variables
    private Camera _fpsCamera;
    private CharacterController _controller;

    //Player stats
    public int _hp = 100;
    public Gun _activeGun;
    private Gun[] _gun;
    private Card[] _card; //Make public if we want to have cards replace gun
    public float _jumpHeight = 5f;

    //Owen Added Variable for Poison
    private bool _inPoison = false;
    [SerializeField] private float _acidWaitTime = 1f;
    [SerializeField] private int _acidDamage = 10;

    void Start()
    {
        //Declare initial variable states and/or get references to gameObjects
        //_activeGun = gameObject.GetComponent<Gun>();
        _fpsCamera = Camera.main;
        _controller = GetComponent<CharacterController>();
        //_ray = new Ray();
        Cursor.lockState = CursorLockMode.Locked;
        _rotationSpeed = 7f;
        _xRotation = _yRotation = 0f;
        _card = new Card[3];
        _gun = new Gun[2];
    }

    // Update is called once per frame
    void Update()
    { 
        TurnPlayer();
        Movement();

        if (_hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
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

    private void Fire()
    {
        _activeGun.Shoot();
        Debug.Log("Nice shooting, Tex...");
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Acid")
        {
            if (_inPoison == false)
            {
                Debug.Log("Ow!");
                _hp -= _acidDamage;
                _inPoison = true;
                StartCoroutine(CantBeMelted());
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Card")
        {
            int tempCard = collision.gameObject.GetComponent<Card>()._doorNumber;
            _card[tempCard-1] = collision.gameObject.GetComponent<Card>();
            Debug.Log(_card[tempCard-1]._doorNumber + "st key obtained!");
            //collision.GetComponent<PlayerHealth>().AddCard(card);
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Health")
        {
            Debug.Log("Health acquired!");
            _hp += collision.gameObject.GetComponent<Health>()._healthValue;
            Debug.Log("Current health: " + _hp + "hp!");
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Shells")
        {
            //add to shotgun ammo count
        }
        else if (collision.tag == "Slugs")
        {
            //add to pistol ammo count
        }
        else if (collision.tag == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
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

    private IEnumerator CantBeMelted()
    {
        yield return new WaitForSeconds(_acidWaitTime);
        _inPoison = false;
    }
}
