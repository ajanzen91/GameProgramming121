using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _moveSpeed;
    private float Gravity = -9.81f, JumpHeight = 2f;
    private Vector3 _velocity;
    private CharacterController _controller;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool onGround = _controller.isGrounded;

        


        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //predefinied axes in Unity linked to WASD controllers
        move = transform.TransformDirection(move);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = _runSpeed;
            _animator.SetFloat("KnightMovement", 1, 0.1f, Time.deltaTime);
        }
        else if(!Input.GetKey(KeyCode.LeftShift) && (move.x != 0f || move.z != 0f))
        {
            _moveSpeed = _walkSpeed;
            _animator.SetFloat("KnightMovement", 0.5f, 0.1f, Time.deltaTime);
        }
        else
        {
            _animator.SetFloat("KnightMovement", 0, 0.1f, Time.deltaTime);
        }
        
        _controller.Move(move * Time.deltaTime * _moveSpeed);

        //Vertical movement calculation
        if (onGround && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        if (onGround && Input.GetButton("Jump"))
        {
            _velocity.y += Mathf.Sqrt(-JumpHeight * Gravity);
        }


        _velocity.y += Gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
          
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 1);
        _animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.9f);
       
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 0);
    }
}