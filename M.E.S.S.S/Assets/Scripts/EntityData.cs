using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]

public class EntityData : ScriptableObject
{
    public float wallCheckDistance;
    public float ledgeCheckDistance;
    public float _sightRange;
    public int damage;

    public LayerMask whatIsGround;
}
