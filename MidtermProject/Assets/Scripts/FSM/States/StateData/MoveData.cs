using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMoveData", menuName = "Data/State Data/Move State")]


public class MoveData : ScriptableObject
{
    public float _movementSpeed;
    public float _rotationRate;
    public int _minRotationCooldown = 3;
    public int _maxRotationCooldown = 10;

}
