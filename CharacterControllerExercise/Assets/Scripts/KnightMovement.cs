using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private float Gravity = -9.81f; //acceleration of gravity
    private float _jumpHeight = 1.0f;
    private bool _groundedPlayer;
    private Vector3 _velocity;
    private Text _goldCount;

    private CharacterController _controller; //references Character Controller component
    private Animator _animator; //references Animator component

    private int coins = 0;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>(); //must use GetComponentInChildren because our model is a child of the Player game object, in this case
        _goldCount = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        _groundedPlayer = _controller.isGrounded; //was the character touching the ground during the last frame? Accessing character controller's isGrounded property
        if (_groundedPlayer && _velocity.y < 0)
        {
            _velocity.y = 0f; //if the character was grounded in the last frame and is now moving in a negative velocity (falling down), set the velocity (speed and direction) to zero
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //predefined axes in Unity linked to WASD controlls
        move = transform.TransformDirection(move); //changes direction 

        _controller.Move(move * Time.deltaTime * _moveSpeed);

        _velocity.y += Gravity * Time.deltaTime; //setting velocity in the y direction to the acceleration of gravity in relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); //movement based on velocity

        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) //if the character is moving AND the left shift key is not pressed, use the walking speed
        {
            _moveSpeed = _walkSpeed; //set my movement to walking speed
            _animator.SetFloat("KnightMovement", 0.5f, 0.1f, Time.deltaTime);
        }
        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) //if the character is mpoving and the left shift key IS pressed, use the running speed
        {
            _moveSpeed = _runSpeed; //set my movement to running speed
            _animator.SetFloat("KnightMovement", 1, 0.1f, Time.deltaTime);
        }
        else if (move == Vector3.zero) //if the character is not moving, stand in idle
        {
            _animator.SetFloat("KnightMovement", 0, 0.1f, Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && _groundedPlayer) //predefined jump in Unity-- paired with space bar
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Gravity); //defined on line 94
        }

        _velocity.y += Gravity * Time.deltaTime; //setting velocity in the y direction to the acceleration of gravity in relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); //movement based on velocity

        if (Input.GetKeyDown(KeyCode.Mouse0)) //when the left mouse button is clicked
        {
            StartCoroutine(Attack()); //start coroutine that causes the attack animation
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            ++coins;
            GameObject.Destroy(other.gameObject);
            updateLabel();
        }
    }

    private void updateLabel()
    {
        _goldCount.text = coins.ToString();
    }


    private IEnumerator Attack()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 1); //attack layer is being accessed in it's entirety-- accesses the avatar mask to only utilize certain parts of the body
        _animator.SetTrigger("Attack"); //uses trigger called Atatck

        yield return new WaitForSeconds(0.9f); //wait almost a full second...
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 0); //...before disabling the avatar mask, and returning movement to the entire body 
    }
}