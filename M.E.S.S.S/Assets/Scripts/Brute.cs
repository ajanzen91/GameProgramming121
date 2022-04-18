using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brute : MonoBehaviour
{
    //Rotation variables
    private float _rotationRate;
    public int _rotationSpeed = 10;
    public int _rotationCooldown = 15;
    private int _currentCooldown;
    private Quaternion _newRotation;
    private bool _rotatingFlag;

    //planar movement variables
    private float _moveSpeed;
    public float _walkSpeed = 1f;
    public float _runSpeed = 4f;
    private Rigidbody _rigidbody;

    //ray variables
    private Ray _ray;
    private RaycastHit _seenPlayer;

    //Enemy stats
    public int _damagePerHit = 20;
    public int _attackCoolDown = 5;
    public float _sightRange = 30f;
    private bool _chargingFlag;
    public int _hp = 100;

    //Reference to character object
    private KnightMovement _player;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _ray = new Ray(transform.position, transform.forward);
        _moveSpeed = _walkSpeed;
        _currentCooldown = _rotationCooldown;
        _chargingFlag = false;
        _rotatingFlag = false;
        //_player = 
    }

    void Update()
    {
        _chargingFlag = Physics.Raycast(transform.position, transform.forward, out _seenPlayer, Mathf.Infinity);
       //Debug.Log(_chargingFlag);

        if (_chargingFlag)
        {
            Charge();
        }
        else
        {
            Wander();
        }
        
        if(_hp <= 0)
        {
            Debug.Log("Brute destroyed!");
            Destroy(this);
        }
    }

    void Wander()
    {
        _moveSpeed = _walkSpeed;

        if (!_rotatingFlag)
        {
            GetWanderDirection();
        }

        transform.Rotate(0, 250 * _rotationSpeed * _rotationRate * Time.deltaTime, 0);
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

    //IEnumerator GetWanderDirection()
    //{
    //    _newRotation = Random.rotation;
    //    _newRotation.x = _newRotation.z = 0f;
    //    _rotationRate = _newRotation.y / _rotationCooldown;
    //    _rotatingFlag = true;

    //    yield return new WaitForSeconds(5f);
    //}

    void GetWanderDirection()
    {
        _newRotation = Random.rotation;
        _newRotation.x = _newRotation.z = 0f;
        _rotationRate = _newRotation.y / _rotationCooldown;
        _rotatingFlag = true;
    }

    void Charge()
    {
        _moveSpeed = _runSpeed;

        _rigidbody.MovePosition(_seenPlayer.point * _moveSpeed * Time.deltaTime);

        //_rigidbody.MovePosition(_seenPlayer.point * Time.deltaTime * _moveSpeed * 1000000000);// *FIX CHARGING BEHAVIOR*
        //transform.Translate(_seenPlayer.point * Time.deltaTime * _moveSpeed);

        //Quaternion deltaRotation = Quaternion.Euler(new Vector 3(0, _xRotation, 0) * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _seenPlayer.transform.rotation, _rotationRate);


    }

    void Attack()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Bullet")
        {
            Debug.Log("Enemy hit!");
            _hp -= collision.gameObject.GetComponent<Bullet>()._damage;
            Destroy(collision.gameObject);
        }
        
    }
}
