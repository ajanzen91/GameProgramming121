using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public int _maxCubes;
    public float _quickestSpawnTime, _slowestSpawnTime;
    public GameObject _baseCube;
    private int numCubes;

    // Start is called before the first frame update
    void Start()
    {
        numCubes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numCubes < _maxCubes)
        {
            StartCoroutine(SpawnCubes());
        }
    }

    IEnumerator SpawnCubes()
    {
        float randomTime = Random.Range(_quickestSpawnTime, _slowestSpawnTime);

       
        Instantiate(_baseCube);
        ++numCubes;

        yield return new WaitForSeconds(randomTime);
    }
}
