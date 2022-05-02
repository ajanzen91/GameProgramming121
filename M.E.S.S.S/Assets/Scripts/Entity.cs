using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine _stateMachine;
    public Rigidbody _rb;
    public GameObject aliveGo;
    public int _hp;
    public State defaultState;
    
    private Vector3 _velocityWorkspace;

    public EntityData _eData;

    public virtual void Start()
    {
        aliveGo = transform.Find("Alive").gameObject;
        _stateMachine = new FiniteStateMachine();
        _rb = aliveGo.GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        _stateMachine._currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        _stateMachine._currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velo)
    {
        _velocityWorkspace.Set(velo, 0, _rb.velocity.z);
        _rb.velocity = _velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics.Raycast(transform.position, aliveGo.transform.right, _eData.wallCheckDistance, _eData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics.Raycast(transform.position, Vector3.down, _eData.ledgeCheckDistance, _eData.whatIsGround);
    }

    public virtual bool DetectPlayer()
    { 
        return Physics.Raycast(transform.position, transform.forward, _eData._sightRange);
    }
        

    public void TakeDamage(int amount)
    {
        _hp -= amount;

        if (_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
