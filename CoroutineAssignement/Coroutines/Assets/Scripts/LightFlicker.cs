using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    //float flickerSpeed = 0.3f;
    //float timeBetweenFlicker = 5f;
    [SerializeField] float flickerSpeed;
    [SerializeField] float timeBetweenFlicker;
    [SerializeField] Light lightObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lightFlicker(flickerSpeed, timeBetweenFlicker, lightObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator lightFlicker(float flSp, float flCooldown, Light light)
    {

    }
}
