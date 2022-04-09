using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour, IDamage
{
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
