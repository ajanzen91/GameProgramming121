using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    public int _amount;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().XpGain(_amount);
            Destroy(this.gameObject);
        }
    }
}
