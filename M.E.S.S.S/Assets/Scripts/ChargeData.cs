using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newChargeData", menuName = "Data/State Data/Charge State")]

public class ChargeData : ScriptableObject
{
    public float chargeSpeed;
    public int damage;
}
