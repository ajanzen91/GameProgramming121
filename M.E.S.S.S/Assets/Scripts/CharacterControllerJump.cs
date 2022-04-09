using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerJump : MonoBehaviour
{
    public float Speed = 10f, Gravity = -9.81f, JumpHeight = 1.0f;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _onGround;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _onGround = _controller.isGrounded; //Was character on ground during last frame

        if(_onGround && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //predefinied axes in Unity linked to WASD controllers
        _controller.Move(move * Time.deltaTime * Speed);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        if(Input.GetButton("Jump")  && _onGround) //predefined jump in Unity, mapped to spacebar
        {
            _velocity.y += Mathf.Sqrt(JumpHeight * -3f * Gravity);
        }

        _velocity.y += Gravity * Time.deltaTime; //Setting the y velocity in the y direction to Earth's grav accell constant
        _controller.Move(_velocity * Time.deltaTime);
    }
}
