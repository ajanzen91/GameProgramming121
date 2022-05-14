using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    public float _xRotation;
    public float _yRotation;

    //public Transform camTarget;

    private Transform parent;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Confined;
        //transform.position = new Vector3(parent.position.x + .95f, parent.position.y + 1.31f, parent.position.z - 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera.ScreenToViewportPoint(Input.mousePosition).x <= .3f || _camera.ScreenToViewportPoint(Input.mousePosition).x >= .7f)
        {
            _xRotation += Input.GetAxis("Mouse X");
        }
        else
        {
            _xRotation = 0;
        }
        if (_camera.ScreenToViewportPoint(Input.mousePosition).y <= .25f || _camera.ScreenToViewportPoint(Input.mousePosition).y >= .6f)
        {
            _yRotation += Input.GetAxis("Mouse Y");
        }
        _yRotation = Mathf.Clamp(_yRotation, -25, 85);
        parent.Rotate(0, _xRotation, 0, Space.World);
        transform.localRotation = Quaternion.Euler(-_yRotation, 0, 0);
    }
}
