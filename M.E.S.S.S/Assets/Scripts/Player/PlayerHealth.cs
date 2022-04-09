using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float healthAmount = 100;
    public float cardAmount = 0;

    private void Update()
    {
        if (healthAmount <= 0)
        {
            Debug.Log("you lose");
            Application.LoadLevel(Application.loadedLevel);
        }
        if (cardAmount >= 1)
        {
            Debug.Log("[THE DOOR IS OPEN]");
            //GameObject.FindGameObjectWithTag("Door");
            //DestroyObject(Door);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;

    }

    public void AddHealth(float value)
    {
        healthAmount += value;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

    }
    public void AddCard(float card)
    {
        cardAmount += card;
        cardAmount = Mathf.Clamp(cardAmount, 0, 1);
    }
}