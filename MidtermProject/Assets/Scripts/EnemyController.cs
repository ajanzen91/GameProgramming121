using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius;
    public int _hp;
    public int _damage;
    public Transform target;
    public PlayerStats _playerStats;
    NavMeshAgent agent;
    private Animator _animator;
    public float _moveSpeed;
    public float _walkSpeed;
    public float _runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        Run();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                Attack();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position = transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void TakeDamage(int amount)
    {
        _hp -= amount;

        if (_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Walk()
    {
        _moveSpeed = _walkSpeed; //set my movement to walking speed
        _animator.SetFloat("SpSwMove", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        _moveSpeed = _runSpeed; //set my movement to running speed
        _animator.SetFloat("SpSwMove", 1f, 0.1f, Time.deltaTime);
    }

    private void Idle()
    {
        _moveSpeed = 0;
        _animator.SetFloat("SpSwMove", 0f, 0.1f, Time.deltaTime); //blending tree value of 0 equates to idle animation
    }

    private void Attack()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack"), 1); //attack layer is being accessed in it's entirety-- accesses the avatar mask to only utilize certain parts of the body
        _animator.SetTrigger("Attack"); //uses trigger called Atatck
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 0); //...before disabling the avatar mask, and returning movement to the entire body 

        //_playerStats._hp -= _damage;
    }
}
