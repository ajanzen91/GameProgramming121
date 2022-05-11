using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : MonoBehaviour
{
    public int _damageDealt;
    public int _type; //Fire = 1, Ice = 2, Lightning = 3, Water = 4
    private int _typeWeakness; //Fire and ice, lightning and water
    private int _xpEarned;
    private float spawnX, spawnY, spawnZ;
    public float _fallSpeed;
    private Vector3 _velocity;
    public Material _fireMaterial, _iceMaterial, _lightMaterial, _waterMaterial;

    void Start()
    {
        _type = (int)Random.Range(1, 4.9f);
        spawnX = Random.Range(-20f, 20f);
        spawnY = Random.Range(10f, 15f);
        spawnZ = Random.Range(-20f, 20f);
        _fallSpeed = Random.Range(-.05f, -.1f);
        _xpEarned = Random.Range(1, 3);

        transform.position = new Vector3(spawnX, spawnY, spawnZ);

        switch (_type)
        {
            case 1:
                {
                    GetComponent<MeshRenderer>().material = _fireMaterial;
                    _typeWeakness = 2;
                    break;
                }
            case 2:
                {
                    GetComponent<MeshRenderer>().material = _iceMaterial;
                    _typeWeakness = 1;
                    break;
                }
            case 3:
                {
                    GetComponent<MeshRenderer>().material = _lightMaterial;
                    _typeWeakness = 4;
                    break;
                }
            case 4:
                {
                    GetComponent<MeshRenderer>().material = _waterMaterial;
                    _typeWeakness = 3;
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().Damage(_damageDealt);
            Destroy(this.gameObject);
        }
        if(other.tag == "Spell")
        {
            if(_typeWeakness == other.GetComponent<Spell>()._type)
            {
                Destroy(this.gameObject);
                //Instantiate XP item
            }
            //if same type, increase size of obj and damageDealt??
        }
    }
}
