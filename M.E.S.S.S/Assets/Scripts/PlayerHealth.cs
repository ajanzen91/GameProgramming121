using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float healthAmount = 100;
    public float cardAmount = 0;

    private GameObject _door;
    private bool _canBeDamaged = true;

    [SerializeField] private float damage;
    [SerializeField] private float _bufferTime = 1f;

    private void Update()
    {
        if (healthAmount <= 0)
        {
            Debug.Log("you lose");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (cardAmount >= 1)
        {
            Debug.Log("[THE DOOR IS OPEN]");
            _door = GameObject.FindGameObjectWithTag("Door");
            Object.Destroy(_door);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Acid")
        {
            if (_canBeDamaged == true)
            {
                Debug.Log("OUCH!");
                healthAmount -= damage;
                _canBeDamaged = false;
                StartCoroutine(DamageBuffer());
            }
        }

        if (collision.tag == "Card")
        {
            AddCard(1);
        }

        if (collision.tag == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private IEnumerator DamageBuffer()
    {
        yield return new WaitForSeconds(_bufferTime);
        _canBeDamaged = true;
    }

    /*
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;

    }
    */

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