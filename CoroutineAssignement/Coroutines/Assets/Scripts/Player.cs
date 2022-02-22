using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Coroutines assignment - Austin Janzen
 * Player.cs
 * Make player slowly fade away and then
 * disappear a la Goldeneye 007 on N64
 */

public class Player : MonoBehaviour
{
    float fadeOutSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeOut(fadeOutSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator fadeOut(float fadeOutspeed)
    {
        
        while (this.GetComponent<Renderer>().material.color.a > 0)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeOutSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;
        }
       

        
        /*
            this.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(fadeOutSpeed / 5);
        */

    }
}
