using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int _HealthRestored;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().Heal(_HealthRestored);
            Destroy(this.gameObject);
        }

    }
}
