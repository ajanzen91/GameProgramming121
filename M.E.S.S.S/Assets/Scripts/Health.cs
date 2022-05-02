using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int healthValue;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("NICE! +20");
            collision.GetComponent<KnightMovement>().AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
