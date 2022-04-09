using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    public int health = 10;

    public void TakeDamage()
    {
        health--;
    }
}
