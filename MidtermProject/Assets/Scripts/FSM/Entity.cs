using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine _stateMachine;
    public Rigidbody _rb;
    public GameObject _aliveObject;
    public int _hp;
    public State _defaultState;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
