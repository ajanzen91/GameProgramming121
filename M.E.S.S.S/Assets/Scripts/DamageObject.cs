using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    /*
    [SerializeField] private float damage;
    [SerializeField] private float _bufferTime = 1f;
    
    private bool _canBeDamaged;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player")
        {
            if (_canBeDamaged == true)
            {
                Debug.Log("OUCH!");
                //collision.GetComponent<PlayerHealth>().TakeDamage(damage);
                _canBeDamaged = false;
                StartCoroutine(DamageBuffer());
            }
        }
    }

    private IEnumerator DamageBuffer()
    {
        yield return new WaitForSeconds(_bufferTime);
        _canBeDamaged = true;
    }
    */
}
