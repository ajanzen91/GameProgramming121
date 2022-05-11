using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public int _damage;
    public int _maxCasts, _remainingCasts;
    public string _spellName;
    public int _type; //Fire = 1, Ice = 2, Lightning = 3, Water = 4
    private int _typeWeakness; //Fire and ice, lightning and water

    void Start()
    {
        switch (_type)
        {
            case 1:
                {
                    _typeWeakness = 2;
                    break;
                }
            case 2:
                {
                    _typeWeakness = 1;
                    break;
                }
            case 3:
                {
                    _typeWeakness = 4;
                    break;
                }
            case 4:
                {
                    _typeWeakness = 3;
                    break;
                }
        }
    }

    void Update()
    {
        
    }
}
