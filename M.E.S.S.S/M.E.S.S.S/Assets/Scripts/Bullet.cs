using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int _damage;
    public bool _fired;

    // Start is called before the first frame update
    void Start()
    {
        _fired = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fired)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
