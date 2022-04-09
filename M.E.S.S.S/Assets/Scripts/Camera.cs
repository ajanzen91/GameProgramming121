//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Camera : MonoBehaviour
//{
////    //private float _xSensitivity = f;
////    //private float _ySensitivity = 1f;

////    private float _moveSpeed;
////    private float _walkSpeed = 1f;
////    private float _runSpeed = 5f;

////    private float Gravity = -9.81f; //acceleration of gravity
////    private float _jumpHeight = 1.0f;
////    private bool _groundedPlayer;
////    private Vector3 _velocity;

////    private Transform parent;
////    private Camera _fpsCamera;
////    private CharacterController _controller; //references Character Controller component

////    private GameObject _gun;

////    // Start is called before the first frame update
//    void Start()
//    {

////        _fpsCamera = Camera.main;
////        parent = transform.parent;
////        Cursor.lockState = CursorLockMode.Locked;


//    }

////    // Update is called once per frame
////    void Update()
////    {

////        float horizontalRotation = Input.GetAxis("Mouse X");
////        float verticalRotation = Input.GetAxis("Mouse Y");

////        parent.Rotate(0, horizontalRotation, 0);
////        _fpsCamera.transform.Rotate(-verticalRotation, 0, 0);


////        Movement();

////        parent.Rotate(Vector3.up, movementX);

////    }

////    private void Movement()
////    {
////        _groundedPlayer = _controller.isGrounded;

////        if (_groundedPlayer && _velocity.y < 0)
////        {
////            _velocity.y = 0f;
////        }

////        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //predefined axes in Unity linked to WASD controlls
////        move = transform.TransformDirection(move); //changes direction 

////        _controller.Move(move * Time.deltaTime * _moveSpeed);

////        _velocity.y += Gravity * Time.deltaTime; //setting velocity in the y direction to the acceleration of gravity in relation to our fps (Time.deltaTime)
////        _controller.Move(_velocity * Time.deltaTime); //movement based on velocity

////        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
////        {
////            Walk();
////        }
////        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
////        {
////            Run();
////        }
////        if (Input.GetButtonDown("Jump") && _groundedPlayer)
////        {
////            Jump();
////        }


////    }

////    private void Walk()
////    {
////        _moveSpeed = _walkSpeed; //set my movement to walking speed
////    }

////    private void Run()
////    {
////        _moveSpeed = _runSpeed;
////    }

////    private void Jump()
////    {
////        _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Gravity); //change velocity to reflect a jumping behavior
////    }

////    private IEnumerator Attack()
////    {
////        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 1); //attack layer is being accessed in it's entirety-- accesses the avatar mask to only utilize certain parts of the body
////        _animator.SetTrigger("Attack"); //uses trigger called Atatck

////        yield return new WaitForSeconds(0.9f); //wait almost a full second...
////        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 0); //...before disabling the avatar mask, and returning movement to the entire body 
////    }
//}
