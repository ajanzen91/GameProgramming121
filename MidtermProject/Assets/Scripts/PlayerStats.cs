using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour //Maybe an abstract class in the future?
{
    public int _hp;
    public int _score;
    public Spell _activeSpell;
    public Spellbook _spellbook;

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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Spell")
    //    {
    //        if (_activeSpell == null || _activeSpell._remainingCasts == 0)
    //        {
    //            _spellbook.InstantiateSpell(other.GetComponent<Spell>());
    //            Destroy(other.gameObject);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _hp -= other.GetComponent<EnemyController>()._damage;
        }
    }
}
