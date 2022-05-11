using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour //Maybe an abstract class in the future?
{
    public int _hp;
    public int _score;

    public void Heal(int amount)
    {
        _hp += amount;
    }

    public void Damage(int amount)
    {
        _hp -= amount;

        if(_hp <= 0)
        {
            //Die
        }
    }

    public void XpGain(int amount)
    {
        _score += amount;
    }
}
