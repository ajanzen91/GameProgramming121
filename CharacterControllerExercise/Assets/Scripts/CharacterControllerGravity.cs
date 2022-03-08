using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerGravity : MonoBehaviour
{
    public float Speed = 10f, Gravity = -9.81f;

    private CharacterController _controller;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //predefinied axes in Unity linked to WASD controllers
        _controller.Move(move * Time.deltaTime * Speed);

        _velocity.y += Gravity * Time.deltaTime; //Setting the y velocity in the y direction to Earth's grav accell constant
        _controller.Move(_velocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }
}
